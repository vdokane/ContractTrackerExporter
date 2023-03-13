using ContractTracker.Repository.Context;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using ContractTracker.Repository.Implementation;
using Microsoft.EntityFrameworkCore;

namespace ContractTracker.Repository.CommandRepositories
{
    public class ExportLogCommandRepository : IExportLogCommandRepository
    {
        private readonly TrackerDbContext context;
        public ExportLogCommandRepository(IUnitOfWork unitOfWork)
        {
            context = unitOfWork.GetContext();
        }

        public async Task InsertExportLog(ExportLog entity)
        {
            var newEntity = await context.ExportLog.AddAsync(entity);
            await context.SaveChangesAsync();
            //return newEntity. Hm? What is the best way to make sure it saved correctly?
        }
    }
}
