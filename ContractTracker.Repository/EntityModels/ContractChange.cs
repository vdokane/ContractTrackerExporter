using System;
using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class ContractChange
    {
        [Key]
        public int ContractChangeID { get; set; }
        public int ContractID { get; set; }
        public string ContractChangeType { get; set; } = string.Empty;
        public decimal AmendmentAmount { get; set; }
        public string AmendmentReference { get; set; } = string.Empty;
        public DateTime AmendmentEffectiveDate { get; set; }
        public DateTime ChangeDateExecuted { get; set; }
        public DateTime? NewEndingDate { get; set; }
        public string ChangeDescription { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public DateTime? ExportDate { get; set; }
        public int UserID { get; set; } = 0;
        public DateTime? Timestamp { get; set; }
        public int? FACTSContractCHangeID { get; set; }
        public bool? MarkedForDeletion { get; set; }
    }
}
