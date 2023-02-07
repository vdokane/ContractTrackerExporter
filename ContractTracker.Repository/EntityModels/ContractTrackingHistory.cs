using System;
using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class ContractTrackingHistory
    {
        [Key]
        public int ContractTrackingHistoryID { get; set; }
        public int ContractID { get; set; }
        public int ContractTrackingStepsID { get; set; }
        public int? ContractChangeID { get; set; }
        public string Message { get; set; } = string.Empty;
        public int UserID { get; set; }
        public DateTime TimeStamp { get; set; }

    }
}
