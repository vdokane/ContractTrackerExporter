
namespace FileExporter.ExportModels
{
    public class BudgetExportModel
    {
        public int BudgetId { get; set; }
        public int ContractId { get; set; }
        public int? FlairCodeId { get; set; }
        public string OrgCode { get; set; } = string.Empty; //Are these going to be needed? TODO
        public string EO { get; set; } = string.Empty; //Are these going to be needed? TODO
        public string Category { get; set; } = string.Empty; //Are these going to be needed? TODO
        public string AgencyAmendmentReference { get; set; } = string.Empty;
        public decimal BudgetaryAmount { get; set; }
        public string BudgetaryAmountType { get; set; } = string.Empty;
        public string BudgetaryAmountAccountCode { get; set; } = string.Empty;
        public string OtherCostAccumulater { get; set; } = string.Empty;
        public DateTime? FiscalYearEffectiveDate { get; set; }
        public DateTime? EffectiveBeginDate { get; set; }
        public DateTime? EffectiveEndDate { get; set; }
        public decimal BudgetaryRate { get; set; }
        public bool? MarkedForDeletion { get; set; }
        //public int CreatedByUserId { get; set; }
        //public DateTime? CreatedDate { get; set; }
        //public int? LastUpdateByUserId { get; set; }
        //public DateTime? LastUpdateDate { get; set; }
        public int? ContractAppBudgetId { get; set; }
        public DateTime? ExportDate { get; set; }
    }
}
