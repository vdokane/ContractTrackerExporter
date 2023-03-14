using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using FileExporter.ExportModels;

namespace FileExporter.Services
{
    public class ExportLogService
    {
        private readonly IExportLogCommandRepository exportLogCommandRepository;
        public ExportLogService(IExportLogCommandRepository exportLogCommandRepository)
        {
            this.exportLogCommandRepository = exportLogCommandRepository;
        }

        public async Task InsertExportLog(ExportLogRequestModel requestModel)
        {
            var newLogEntity = new ExportLog();
            newLogEntity.Step = requestModel.Step.ToString();
            newLogEntity.InsertDate = requestModel.InsertDate;
            newLogEntity.ExportDescription = requestModel.StepDescription;
            newLogEntity.ContractNumber = requestModel.ContractNumber;
            try
            {
                await exportLogCommandRepository.InsertExportLog(newLogEntity);
            }
            catch { } //Fail silently, let the export process keep building the file.
        }
    }
}
