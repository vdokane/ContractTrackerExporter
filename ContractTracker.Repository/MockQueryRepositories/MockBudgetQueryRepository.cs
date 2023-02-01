using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;


namespace ContractTracker.Repository.MockQueryRepositories
{
    public class MockBudgetQueryRepository : IBudgetQueryRepository
    {
        private readonly List<ContractBudget> SeedBudgetDate;
        public MockBudgetQueryRepository()
        {
            SeedBudgetDate = SeedBudgets();
        }

        public async Task<List<ContractBudget>> GetBudgetsByContractId(int contractId)
        {
            var entities = SeedBudgetDate.Where(e => e.ContractId == contractId).ToList();
            return await Task.FromResult(entities);
        }

        private List<ContractBudget> SeedBudgets()
        {
           var budgets = new List<ContractBudget>();
            budgets.Add(new ContractBudget() { BudgetaryAmount = 34, BudgetaryAmountType   = "NR", ContractBudgetID = 1, ContractId = 1 });
            budgets.Add(new ContractBudget() { BudgetaryAmount = 43, BudgetaryAmountType = "NR", ContractBudgetID = 2, ContractId = 1 });
            budgets.Add(new ContractBudget() { BudgetaryAmount = 34, BudgetaryAmountType = "NR", ContractBudgetID = 3, ContractId = 2 });
            budgets.Add(new ContractBudget() { BudgetaryAmount = 43, BudgetaryAmountType = "NR", ContractBudgetID = 4, ContractId = 2 });
            return budgets;
        }
    }
}
