using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractTracker.Repository.EntityModels
{
    public class Delete_Amendments
    {
        [Key]
        public int AmendmentId { get; set; }
        public int ContractId { get; set; }
        public string ChangeType { get; set; }
        public decimal AmendmentAmount { get; set; }
        public string AmendmentReference { get; set; }
        public DateTime AmendmentEffectiveDate { get; set; }
        public DateTime ChangeDateExecuted { get; set; }
        public DateTime? NewEndingDate { get; set; }
        public string ChangeDescription { get; set; } = null!
        public DateTime Action { get; set; }
       
        public bool? MarkedForDeletion { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
