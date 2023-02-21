using System;
using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class TrackingHistory
    {
        [Key]
        public int TrackingHistoryId { get; set; }
        public int ContractId { get; set; }
        public int TrackingStepId { get; set; }
        public int? AmmendmentId { get; set; }
        public string Message { get; set; }
        public int UserID { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
