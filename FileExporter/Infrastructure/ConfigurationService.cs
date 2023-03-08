using Microsoft.Extensions.Configuration; //Install this from NuGet: Microsoft.Extensions.Configuration and Microsoft.Extensions.Configuration.Json

namespace FileExporter.Infrastructure
{
    internal class ConfigurationService
    {
        private readonly IConfigurationRoot configuration;
        public ConfigurationService()
        {
            configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        }
        public string? GetConnectionString()
        {
            var value = configuration.GetConnectionString("TrackerConnection");
            return value;
        }
        public string? GetDocPath()
        {
            var value = configuration.GetConnectionString("DocPath");
            return value;
        }
        public string? GetAttachmentPath()
        {
            var value = configuration.GetConnectionString("AttachmentPath");
            return value;
        }
        public string? GetAattachmentIndexPath()
        {
            var value = configuration.GetConnectionString("AattachmentIndexPath");
            return value;
        }
        public string? GetAattachmentPathCompressed()
        {
            var value = configuration.GetConnectionString("AattachmentPathCompressed");
            return value;
        }

    }
}
