using ContractTracker.Repository.Context;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using ContractTracker.Repository.Implementation;
using Microsoft.EntityFrameworkCore;

namespace ContractTracker.Repository.QueryRepositories
{
    public class ContractQueryRepository : IContractQueryRepository
    {
        private readonly TrackerDbContext context;

        public ContractQueryRepository(IUnitOfWork unitOfWork)
        {
            context = unitOfWork.GetContext();
        }

        public async Task<List<Contracts>> GetAllContractsReadyToBeSubmitted(List<int> allContractIds)
        {
            if (allContractIds.Count == 0)
                return new List<Contracts>();

            var allEntities = await context.Contracts
                .Where(x => allContractIds.Contains(x.ContractID))
                .Include(i => i.MethodOfProcurementCodes)
                .AsNoTracking()
                .ToListAsync();
            return allEntities;
        }
    }
}
