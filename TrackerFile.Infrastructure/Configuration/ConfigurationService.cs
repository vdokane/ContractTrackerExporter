using Microsoft.Extensions.Configuration; //Install this from NuGet: Microsoft.Extensions.Configuration and Microsoft.Extensions.Configuration.Json

namespace TrackerFile.Infrastructure.Configuration
{
    public class ConfigurationService
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

        public string GetErrorFilePath()
        {
            return GetSectionGracefully("ErorrFilePath");
        }

        private string GetSectionGracefully(string sectionName)
        {
            var section = configuration.GetSection(sectionName);
            if(section == null)
                return string.Empty;

            return (section.Exists()) ? section.Value : string.Empty;
        }
    }
}
