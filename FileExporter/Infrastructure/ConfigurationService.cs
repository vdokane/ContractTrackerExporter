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
            return GetSectionGracefully("DocPath");
        }
        public string? GetAttachmentPath()
        {
            return GetSectionGracefully("AttachmentPath");
        }
        public string? GetAattachmentIndexPath()
        {
            return GetSectionGracefully("AattachmentIndexPath");
        }
        public string? GetAattachmentPathCompressed()
        {
            return GetSectionGracefully("AattachmentPathCompressed");
        }

        private string GetSectionGracefully(string sectionName)
        {
            var section = configuration.GetSection(sectionName);
            return (section.Exists()) ? section.Value : string.Empty;
        }
    }
}
