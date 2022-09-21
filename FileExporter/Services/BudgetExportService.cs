using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileExporter.ExportModels;

namespace FileExporter.Services
{
    public class BudgetExportService
    {
        public List<BudgetModel> GetBudgetModelsByContractId(int contractId)
        {
            var seerder = new Seeder();
            var allBudget = seerder.SeedBudgets().Where(x => x.ContractId == contractId).ToList();
            return allBudget;
        }
    }
}
