// See https://aka.ms/new-console-template for more information
using FileExporter.ExportModels;
using FileExporter.Services;

Console.WriteLine("Starting to export!");
var seeder = new Seeder();
//var contractModel = seeder.SeedContractModel();
//var budgetLineItems = seeder.SeedBudgets();
//C:\Users\vdoka\source\repos\FileExporter\FileExporter\file

string[] lines = { "First line", "Second line", "Third line" };
const string newLine = "--------";
// Set a variable to the Documents path.
string docPath = @"C:\Users\vdoka\source\repos\FileExporter\FileExporter\file";

var contractExportService = new ContractExportService();
var budgetExportService = new BudgetExportService();
// Write the string array to a new file named "WriteLines.txt".
using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Sample1.csv")))
{
    var allContractsReadyToExport = contractExportService.GetContractsForExporting();
    foreach (var contractModel in allContractsReadyToExport)
    {
        Console.WriteLine($"Exporting Contract: {contractModel.ContractName}");
        //TODO, do I want to use CsvHelper to parse or build it in the service?
        outputFile.WriteLine(contractModel.ContractName);
        outputFile.WriteLine(newLine);
        var allBudgetRecordsForContract = budgetExportService.GetBudgetModelsByContractId(contractModel.ContractId);
        foreach(var budgetRecord in allBudgetRecordsForContract)
        {
            outputFile.WriteLine(budgetRecord.BudgetDesc);
        }
        outputFile.WriteLine(newLine);

    }
    Console.WriteLine($"Done");
}
