using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractTracker.Repository.EntityModels
{
    public class ContractDeliverables
    {
        [Key]
        public int DeliverableID { get; set; }
        public int ContractID { get; set; }
        
        
        public int? MethodOfPaymentID { get; set; }
        
        [ForeignKey("MethodOfPaymentID")]
        public virtual MethodOfPayments? MethodOfPayments { get; set; } = null!;
         
        public string? MajorDeliverable { get; set; } = string.Empty;
        public decimal? DeliverablePrices { get; set; }
        public int? NonPriceJustification { get; set; }
        public string? PerformanceMatrix { get; set; } = string.Empty;
        public string? FinancialConsequences { get; set; } = string.Empty;
        public string? DocumentationPageReference { get; set; } = string.Empty;
        public string CommodityCode { get; set; } = string.Empty;
        public bool? MarkedForDeletion { get; set; }
        public bool? Archive { get; set; }
        public DateTime? ExportDate { get; set; }

    }
}
