

namespace FileExporter.ExportModels
{
    public class DeliverableExportModel
    {
        public int DeliverableId { get; set; }
        public int ContractId { get; set; }
        public int? MethodOfPaymentId { get; set; }
        public string PaymentDescription { get; set; } = string.Empty;
        public string MajorDeliverable { get; set; } = string.Empty;
        public decimal DeliverablePrices { get; set; }
        public int? NonPriceJustification { get; set; }
        public string PerformanceMatrix { get; set; } = string.Empty;
        public string FinancialConsequences { get; set; } = string.Empty;
        public string DocumentationPageReference { get; set; } = string.Empty;
        public string CommodityCode { get; set; } = string.Empty;
        public DateTime? ExportDate { get; set; }
         
             
    }
}
