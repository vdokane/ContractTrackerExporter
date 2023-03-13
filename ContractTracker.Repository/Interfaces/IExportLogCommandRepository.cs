using ContractTracker.Repository.EntityModels;

namespace ContractTracker.Repository.Interfaces
{
    public interface IExportLogCommandRepository
    {
        Task InsertExportLog(ExportLog entity);
    }
}
