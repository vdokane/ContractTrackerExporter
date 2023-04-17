using TrackerFile.Infrastructure.Utilities;

namespace FileExporter.ExportModels
{
    public class ExportLogRequestModel
    {
        public string ContractNumber { get; set; } = string.Empty;
        public DateTime InsertDate { get; set; }
        public ExportSteps Step { get; set; }
        public string StepDescription { get;set; } = string.Empty;
    }
}
