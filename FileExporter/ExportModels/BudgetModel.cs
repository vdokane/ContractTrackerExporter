
namespace FileExporter.ExportModels
{
    public class BudgetModel
    {
        public int BudgetId { get; set; }  = 0;
        public int ContractId { get; set; } = 0;
        public decimal Amount { get; set; } = 0;
        public string BudgetDesc { get; set; } = string.Empty;
    }
}
