
namespace FileExporter.ExportModels
{
    internal class Seeder
    {
        public List<ContractModel> SeedContractModels()
        {
            List<ContractModel> contracts = new List<ContractModel>();
            contracts.Add( new ContractModel() { ContractId = 1, ContractName = "SC0018", StartDate = DateTime.Now });
            contracts.Add( new ContractModel() { ContractId = 2, ContractName = "SC0019", StartDate = DateTime.Now });
            return contracts;
        }

        public List<BudgetModel> SeedBudgets()
        {
            List<BudgetModel> budgets = new List<BudgetModel>();
            budgets.Add(new BudgetModel() { Amount = 34, BudgetDesc = "budget desc 1", BudgetId = 1, ContractId = 1 });
            budgets.Add(new BudgetModel() { Amount = 43, BudgetDesc = "budget desc 2", BudgetId = 2, ContractId = 1 });
            budgets.Add(new BudgetModel() { Amount = 34, BudgetDesc = "budget desc 3", BudgetId = 3, ContractId = 2 });
            budgets.Add(new BudgetModel() { Amount = 43, BudgetDesc = "budget desc 4", BudgetId = 4, ContractId = 2 });
            return budgets;
        }
    }
}
