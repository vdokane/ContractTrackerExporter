using ContractTracker.Repository.Context;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using ContractTracker.Repository.Implementation;
using Microsoft.EntityFrameworkCore;

namespace ContractTracker.Repository.QueryRepositories
{
    
    public class BudgetQueryRepository : IBudgetQueryRepository
    {
        private readonly TrackerDbContext context;
        public BudgetQueryRepository(IUnitOfWork unitOfWork)
        {
            context = unitOfWork.GetContext();
        }

        public async Task<List<ContractBudget>> GetBudgetsByContractId(int contractId)
        {
            var entities = await context.Budgets.Where(b => b.ContractId == contractId).AsNoTracking().ToListAsync();
            return entities;
        }

    }
}
