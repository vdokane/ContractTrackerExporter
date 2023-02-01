
namespace FileExporter.ExportModels
{
    internal class Seeder
    {
        public List<ContractExportModel> SeedContractModels()
        {
            List<ContractExportModel> contracts = new List<ContractExportModel>();
            contracts.Add( new ContractExportModel() { ContractId = 1, ContractNumber = "SC0018", StartDate = "1/1/2022" });
            contracts.Add( new ContractExportModel() { ContractId = 2, ContractNumber = "SC0019", StartDate = "1/1/2023" });
            return contracts;
        }

        public List<BudgetExportModel> SeedBudgets()
        {
            List<BudgetExportModel> budgets = new List<BudgetExportModel>();
            budgets.Add(new BudgetExportModel() { Amount = 34, BudgetDesc = "budget desc 1", BudgetId = 1, ContractId = 1 });
            budgets.Add(new BudgetExportModel() { Amount = 43, BudgetDesc = "budget desc 2", BudgetId = 2, ContractId = 1 });
            budgets.Add(new BudgetExportModel() { Amount = 34, BudgetDesc = "budget desc 3", BudgetId = 3, ContractId = 2 });
            budgets.Add(new BudgetExportModel() { Amount = 43, BudgetDesc = "budget desc 4", BudgetId = 4, ContractId = 2 });
            return budgets;
        }
    }
}
