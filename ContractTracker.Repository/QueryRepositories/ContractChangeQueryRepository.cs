using ContractTracker.Repository.Context;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using ContractTracker.Repository.Implementation;
using Microsoft.EntityFrameworkCore;

namespace ContractTracker.Repository.QueryRepositories
{
    public class ContractChangeQueryRepository : IContractChangeQueryRepository
    {
        private readonly TrackerDbContext context;
        public ContractChangeQueryRepository(IUnitOfWork unitOfWork)
        {
            context = unitOfWork.GetContext();
        }

        public async Task<List<ContractChange>> GetChangesByContractId(int contractId)
        {
            var entities = await context.ContractChange.Where(b => b.ContractID == contractId).AsNoTracking().ToListAsync();
            return entities;
        }
    }
}
