// See https://aka.ms/new-console-template for more information
using ContractTracker.Repository.Implementation;
using FileExporter.ExportModels;
using FileExporter.Factory;
using FileExporter.Services;
using System.Text;
 
using System.IO.Compression;
using FileExporter.Infrastructure;

const bool useMock = false;
DateTime today = new DateTime(2023, 1, 25); //DateTime.Today; //TODO, use param 

Console.WriteLine($"Starting to export! {DateTime.Now.ToString()}");

var configurationService = new ConfigurationService();
var connectionString = configurationService.GetConnectionString();
if (connectionString == null)
{
    Console.WriteLine($"Error Getting connectionString {DateTime.Now.ToString()}");
    return;
}
var docPath = configurationService.GetDocPath();
if (docPath == null)
{
    Console.WriteLine($"Error Getting docPath {DateTime.Now.ToString()}");
    return;
}
var attachmentPath = configurationService.GetAttachmentPath();
if (attachmentPath == null)
{
    Console.WriteLine($"Error Getting attachmentPath {DateTime.Now.ToString()}");
    return;
}
var attachmentIndexPath = configurationService.GetAattachmentIndexPath();
if (attachmentIndexPath == null)
{
    Console.WriteLine($"Error Getting attachmentIndexPath {DateTime.Now.ToString()}");
    return;
}
var attachmentPathCompressed = configurationService.GetAattachmentPathCompressed();
if (attachmentPathCompressed == null)
{
    Console.WriteLine($"Error Getting attachmentPathCompressed {DateTime.Now.ToString()}");
    return;
}
var seeder = new Seeder();


 
 
var fileName = new StringBuilder("Sample_Export_").Append(today.ToString("yyyyMMdd")).Append(".txt").ToString();

//Clean up files
if (File.Exists(Path.Combine(docPath, fileName)))
{
    Console.WriteLine($"About to delete file that already exists with same name {DateTime.Now}");
    File.Delete(Path.Combine(docPath, fileName));
}
if (File.Exists(attachmentPathCompressed))
{

    Console.WriteLine($"About to delete ZIP file that already exists with same name {DateTime.Now}");
    File.Delete(attachmentPathCompressed);
} 




var attachmentIndexService = new AttachmentIndexService();
var allAttachmentDocumentsModel = new List<AttachmentIndexModel>();

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
    if (allContractsReadyToExport.Count == 0)
    {
        Console.WriteLine($"Done because no conracts to export {DateTime.Now.ToString()}");
        return;
    }

    //This should probably come from a config
     

    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, fileName)))
    {
        foreach (var contractModel in allContractsReadyToExport)
        {
            Console.WriteLine($"Writing contract {contractModel.ContractNumber} to output file! {DateTime.Now.ToString()}");



            //Main contract record
            var contractLine = contractService.BuildContractRow(contractModel);
            outputFile.WriteLine(contractLine);



            //Budget
            var allBudgetRecordsForContract = await budgetExportService.GetBudgetModelsByContractId(contractModel.ContractId);
            foreach (var budgetRecord in allBudgetRecordsForContract)
            {
                outputFile.WriteLine(budgetExportService.BuildBudgetRow(budgetRecord));
                Console.WriteLine($"Writing budget {budgetRecord.BudgetId} to output file! {DateTime.Now.ToString()}");
            }




            //Vendor ...I think this is wrong.. this is part of contract row?
            //todo query this contract 002Q3
            //WHERE IS SHORT TITLE COMING FROM? LEG-Cons|Legal Services-Consulting
            outputFile.WriteLine(vendorExportService.BuildVendorRow(contractModel));
            Console.WriteLine($"Writing vendor {contractModel.VendorNumber} to output file! {DateTime.Now.ToString()}");

            //Deliverables
            var allDeliverablesForContract = await deliverableExportService.GetDeliverableModelsByContractId(contractModel.ContractId);
            foreach (var deliveryable in allDeliverablesForContract)
            {
                outputFile.WriteLine(deliverableExportService.BuildDeliverableRow(deliveryable));
                Console.WriteLine($"Writing deliverable {deliveryable.DeliverableId} to output file! {DateTime.Now.ToString()}");
            }


            //Contract Changes
            var contractChanges = await contractChangeExportService.GetChangesForExport(contractModel.ContractId);
            foreach (var contractChange in contractChanges)
            {
                outputFile.WriteLine(contractChangeExportService.BuildContractChangeRow(contractChange));
                Console.WriteLine($"Writing change {contractChange.ContractChangeID} to output file! {DateTime.Now.ToString()}");
            }



            //TODO 2023/02/17
            //  create Index.txt
            //  CN-220000-T00B1J.pdf
            //CN|220000|00B1J||CN-220000-T00B1J.pdf|| 




            //Contract Attachments (Original contract and redacted only
            var attachments = await documentAttachmentService.GetAllExportableContractsByDocumentId(contractModel.DocumentID);
            foreach (var attachment in attachments)
            {
                //crap...sorta work. Also, should this go in the using for the output file? 2023/01/02
                var fileNameAndpath = attachmentPath + @"\" + contractModel.ContractNumber + "-" + attachment.AttachmentFileName;

                //outputFile.WriteLine(fileNameAndpath); //Just for testing

                File.WriteAllBytes(fileNameAndpath, attachment.Attachment);
                Console.WriteLine($"Writing contract attachment {attachment.AttachmentFileName} to output file! {DateTime.Now.ToString()}");

                var attachmentIndexModel = new AttachmentIndexModel();
                
                attachmentIndexModel.AttachmentType = AttachmentRowConstants.Contract; //I think?
                //TODO how do I name deliverables?
                attachmentIndexModel.ShortContractNumber = contractModel.ContractNumber; //How do I get short?
                attachmentIndexModel.Unknown1 = string.Empty;
                attachmentIndexModel.Unknown2 = string.Empty;
                attachmentIndexModel.FileName = attachment.AttachmentFileName; //todo, test
                attachmentIndexModel.OLO = "22000"; //To I need this
                allAttachmentDocumentsModel.Add(attachmentIndexModel);
            }

            //Procurment Documents
            var procurements = await documentAttachmentService.GetAllExportableProcurmentsByDocumentId(contractModel.DocumentID);
            foreach (var procurement in procurements)
            {
                //crap...sorta work. Also, should this go in the using for the output file? 2023/01/02
                var fileNameAndpath = attachmentPath + @"\" + contractModel.ContractNumber + "-" + procurement.AttachmentFileName;

                //outputFile.WriteLine(fileNameAndpath); //Just for testing

                File.WriteAllBytes(fileNameAndpath, procurement.Attachment);
                Console.WriteLine($"Writing procurement attachment {procurement.AttachmentFileName} to output file! {DateTime.Now.ToString()}");
                var attachmentIndexModel = new AttachmentIndexModel();

                attachmentIndexModel.AttachmentType = AttachmentRowConstants.Procurement; //I think?
                //TODO how do I name deliverables?
                attachmentIndexModel.ShortContractNumber = contractModel.ContractNumber; //How do I get short?
                attachmentIndexModel.Unknown1 = string.Empty;
                attachmentIndexModel.Unknown2 = string.Empty;
                attachmentIndexModel.FileName = procurement.AttachmentFileName; //todo, test
                attachmentIndexModel.OLO = "22000"; //To I need this
                allAttachmentDocumentsModel.Add(attachmentIndexModel);
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

                var fileNameAndpathOriginal = attachmentPath + @"\" + orginainlContractChangeAttachmentDocument.AttachmentFilename;
                File.WriteAllBytes(fileNameAndpathOriginal, orginainlContractChangeAttachmentDocument.Attachment);
                Console.WriteLine($"Writing change attachment {orginainlContractChangeAttachmentDocument.AttachmentFilename} to output file! {DateTime.Now.ToString()}");

                //outputFile.WriteLine(fileNameAndpathOriginal); //Just for testing
                var attachmentIndexModelChange = new AttachmentIndexModel();
                attachmentIndexModelChange.AttachmentType = AttachmentRowConstants.Change; //I think?
                //TODO how do I name deliverables?
                attachmentIndexModelChange.ShortContractNumber = contractModel.ContractNumber; //How do I get short?
                attachmentIndexModelChange.Unknown1 = string.Empty;
                attachmentIndexModelChange.Unknown2 = string.Empty;
                attachmentIndexModelChange.FileName = orginainlContractChangeAttachmentDocument.AttachmentFilename; //todo, test
                attachmentIndexModelChange.OLO = "22000"; //To I need this
                allAttachmentDocumentsModel.Add(attachmentIndexModelChange);

                if (redactedContractChangeAttachmentDocument == null)
                    continue;

                var fileNameAndpathRedact = attachmentPath + @"\" + redactedContractChangeAttachmentDocument.AttachmentFilename;
                File.WriteAllBytes(fileNameAndpathRedact, redactedContractChangeAttachmentDocument.Attachment);
                Console.WriteLine($"Writing change redacted attachment {redactedContractChangeAttachmentDocument.AttachmentFilename} to output file! {DateTime.Now.ToString()}");

                var attachmentIndexModelChangeRedacted = new AttachmentIndexModel();

                attachmentIndexModelChangeRedacted.AttachmentType = AttachmentRowConstants.Change; //I think?
                //TODO how do I name deliverables?
                attachmentIndexModelChangeRedacted.ShortContractNumber = contractModel.ContractNumber; //How do I get short?
                attachmentIndexModelChangeRedacted.Unknown1 = string.Empty;
                attachmentIndexModelChangeRedacted.Unknown2 = string.Empty;
                attachmentIndexModelChangeRedacted.FileName = redactedContractChangeAttachmentDocument.AttachmentFilename; //todo, test
                attachmentIndexModelChangeRedacted.OLO = "22000"; //To I need this
                allAttachmentDocumentsModel.Add(attachmentIndexModelChangeRedacted);
            }
        }
    }

}

//Create the index file to be zipped up with the attachments
Console.WriteLine($"Creating Index.txt {DateTime.Now}");
using (StreamWriter attachmentIndexFile = new StreamWriter(attachmentIndexPath))
{
    foreach (var attacmentModel in allAttachmentDocumentsModel)
    {
        string attachmentIndexFileRow = attachmentIndexService.BuildAttachmentIndexRow(attacmentModel);
        attachmentIndexFile.WriteLine(attachmentIndexFileRow);
    }

}
Console.WriteLine($"Creating zipfile {DateTime.Now}");
//https://stackoverflow.com/questions/905654/zip-folder-in-c-sharp
ZipFile.CreateFromDirectory(attachmentPath, attachmentPathCompressed);


Console.WriteLine($"Done {DateTime.Now}");

