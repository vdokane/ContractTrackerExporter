using ContractTracker.Repository.Implementation;
using System.Text;
using System.IO.Compression;
using TrackerFile.Infrastructure.Utilities;
using TrackerFile.Infrastructure.Configuration;


// See https://aka.ms/new-console-template for more information
Console.WriteLine($"Starting to import error FACTS error file! {DateTime.Now.ToString()}");

var configurationService = new ConfigurationService();
var connectionString = configurationService.GetConnectionString();
if (connectionString == null)
{
    Console.WriteLine($"Error Getting connectionString {DateTime.Now.ToString()}");
    return;
}
var docPath = configurationService.GetErrorFilePath();
if (docPath == null)
{
    Console.WriteLine($"Error Getting docPath {DateTime.Now.ToString()}");
    return;
}

var errorFileName = "SampleFromEmail.txt";
if (!File.Exists(Path.Combine(docPath, errorFileName)))
{
    Console.WriteLine($"Could not find the error file.");
    return;
  
}

using (var reader = new System.IO.StreamReader(Path.Combine(docPath, errorFileName)))
{
    var line = reader.ReadLine();
    while ((line = reader.ReadLine()) != null)
    {

        //Console.WriteLine(line);
        var components = line.Split(FieldDelimiter.Delimiter);
        foreach(var field in components)
        {
            Console.WriteLine(field);
        }

        //components[0] //error message
        //TODO, what is this? CTCH|
        if (components[1].Trim() == RowConstants.Deliverable)
        {
            //components[2] commodity code
            //components[3] desc
        }

        else if (components[1].Trim() == RowConstants.Vendor)
        {

        }
        else if(components[1].Trim() == RowConstants.Budget)
        {

        }
    }
    //while ((line = reader.ReadLine()) != null)
    //{
    //}
}



        Console.WriteLine($"Done importing FACTS error file! {DateTime.Now.ToString()}");
