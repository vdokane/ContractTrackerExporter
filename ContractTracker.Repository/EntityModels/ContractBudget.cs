using System;
using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class ContractBudget
    {
        [Key]
        public int ContractBudgetID { get; set; }
        public int ContractId { get; set; }
        public int? FlairCodeId { get; set; }
        public string OrgCode { get; set; } //Are these going to be needed? TODO
        public string EO { get; set; } //Are these going to be needed? TODO
        public string Category { get; set; } //Are these going to be needed? TODO
        public string AgencyAmendmentReference { get; set; }
        public decimal BudgetaryAmount { get; set; }
        public string BudgetaryAmountType { get; set; }
        public string BudgetaryAmountAccountCode { get; set; }
        public string OtherCostAccumulater { get; set; }
        public DateTime? FiscalYearEffectiveDate { get; set; }
        public DateTime? EffectiveBeginDate { get; set; }
        public DateTime? EffectiveEndDate { get; set; }
        public decimal BudgetaryRate { get; set; }
        public bool? MarkedForDeletion { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public int? ContractAppBudgetId { get; set; }
        public DateTime? ExportDate { get; set; }
    }
}
