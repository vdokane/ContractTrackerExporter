using ContractTracker.Repository.Context;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using ContractTracker.Repository.Implementation;
using Microsoft.EntityFrameworkCore;


namespace ContractTracker.Repository.QueryRepositories
{
     
    public class DeliverableQueryRepository : IDeliverableQueryRepository
    {
        private readonly TrackerDbContext context;
        public DeliverableQueryRepository(IUnitOfWork unitOfWork)
        {
            context = unitOfWork.GetContext();
        }

        public async Task<List<ContractDeliverables>> GetDeliverablesByContractId(int contractId)
        {
            var entities = await context.ContractDeliverables.Where(b => b.ContractID == contractId).AsNoTracking().ToListAsync();
            return entities;
        }
    }
}
