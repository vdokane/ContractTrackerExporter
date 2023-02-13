// See https://aka.ms/new-console-template for more information
using ContractTracker.Repository.Implementation;
using FileExporter.ExportModels;
using FileExporter.Factory;
using FileExporter.Services;
using System.Text;
using Microsoft.Extensions.Configuration; //Install this from NuGet: Microsoft.Extensions.Configuration and Microsoft.Extensions.Configuration.Json

const bool useMock = false;
DateTime today = new DateTime(2023, 1, 25); //DateTime.Today; //TODO, use param 

Console.WriteLine("Starting to export!");


var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
var connectionString = configuration.GetConnectionString("TrackerConnection");
if (connectionString == null)
{
    Console.WriteLine("Error Getting connectionString");
    return;
}
var seeder = new Seeder();
//var contractModel = seeder.SeedContractModel();
//var budgetLineItems = seeder.SeedBudgets();
//C:\Users\vdoka\source\repos\FileExporter\FileExporter\file

//TODO, this needs to be in appsettings and/or a comman line arg
// Set a variable to the Documents path.
//const string docPath = @"E:\Export\file";
const string docPath = @"C:\Export";
//"Data Source=.;Initial Catalog=Tracker;Integrated Security=True"

//var databaseConnectionString = "Data Source=.;Initial Catalog=Tracker;Integrated Security=True"; //TODO webHostEnvironment.GetDataBaseConnectionString();
var _uowFactory = new UowFactory(connectionString);
using (IUnitOfWork uow = _uowFactory.BuildUnitOfWork())
{
    var businessServiceFactory = new ServiceFactory(uow);
    var contractService = businessServiceFactory.BuildContractExportService(useMock);
    var documentAttachmentService = businessServiceFactory.BuildDocumentAttachmentService(useMock);
    var budgetExportService = businessServiceFactory.BuildBudgetExportService(useMock);
    var vendorExportService = businessServiceFactory.BuildVendorExportService();
    var deliverableExportService = businessServiceFactory.BuildDeliverableExportService(useMock);
    var contractChangeExportService = businessServiceFactory.BuildContractChangeExportService(useMock);
    var contractChangeAttachmentExportService = businessServiceFactory.BuildContractChangeAttachmentExportService(useMock);

    //Do work starts here
    var allContractsReadyToExport = await contractService.GetContractsForExporting(today);
    if(allContractsReadyToExport.Count == 0)
    {
        Console.WriteLine("Done because no conracts to export");
            return;
    }

    //This should probably come from a config
    var fileName = new StringBuilder("Sample_Export_").Append(today.ToString("yyyyMMdd")).Append(".txt").ToString();

    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, fileName)))
    {
        foreach (var contractModel in allContractsReadyToExport)
        {
            Console.WriteLine($"Writing contract {contractModel.ContractNumber} to output file!");
             


            //Main contract record
            var contractLine = contractService.BuildContractRow(contractModel);
            outputFile.WriteLine(contractLine);

            continue; //Just for testing

            //Budget
            var allBudgetRecordsForContract = await budgetExportService.GetBudgetModelsByContractId(contractModel.ContractId);
            foreach (var budgetRecord in allBudgetRecordsForContract)
            {
                outputFile.WriteLine(budgetExportService.BuildBudgetRow(budgetRecord));
            }

            //Vendor
            outputFile.WriteLine(vendorExportService.BuildVendorRow(contractModel));

            //Deliverables
            var allDeliverablesForContract = await deliverableExportService.GetDeliverableModelsByContractId(contractModel.ContractId);
            foreach (var deliveryable in allDeliverablesForContract)
            {
                outputFile.WriteLine(deliverableExportService.BuildDeliverableRow(deliveryable));
            }


            //Contract Changes
            var contractChanges = await contractChangeExportService.GetChangesForExport(contractModel.ContractId);
            foreach (var contractChange in contractChanges)
            {
                outputFile.WriteLine(contractChangeExportService.BuildContractChangeRow(contractChange));
            }

            //Contract Attachments
            var attachments = await documentAttachmentService.GetAllDocumentsByDocumentId(contractModel.DocumentID);
            foreach (var attachment in attachments)
            {
                //crap...sorta work. Also, should this go in the using for the output file? 2023/01/02
                var fileNameAndpath = docPath + @"\" + attachment.AttachmentFileName;
                File.WriteAllBytes(fileNameAndpath, attachment.Attachment);
            }


            //ContractChange Attachments
            foreach (var contractChange in contractChanges)
            {
                //TODO, what other data do these files need/naming, etc? 
                var orginainlContractChangeAttachmentDocument = await contractChangeAttachmentExportService.GetOriginalContractChangeAttachmentExportModel(contractChange.ContractChangeID);
                if (orginainlContractChangeAttachmentDocument == null)
                    continue;

                var redactedContractChangeAttachmentDocument
                     = await contractChangeAttachmentExportService.GetRedactedContractChangeAttachmentExportModelById(orginainlContractChangeAttachmentDocument.ContractChangeAttachmentId);

                var fileNameAndpathOriginal = docPath + @"\" + orginainlContractChangeAttachmentDocument.AttachmentFilename;
                File.WriteAllBytes(fileNameAndpathOriginal, orginainlContractChangeAttachmentDocument.Attachment);

                if (redactedContractChangeAttachmentDocument == null)
                    continue;

                var fileNameAndpathRedact = docPath + @"\" + redactedContractChangeAttachmentDocument.AttachmentFilename;
                File.WriteAllBytes(fileNameAndpathRedact, redactedContractChangeAttachmentDocument.Attachment);
            }
        }
    }

}



Console.WriteLine($"Done");

