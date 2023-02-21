using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractTracker.Repository.EntityModels
{
    public class Documents
    {
        [Key]
        public int DocumentID { get; set; }
        public int? CostCenterId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public int UserId { get; set; }
        public DateTime TimeStamp { get; set; }
        public int DocumentStatusTypeID { get; set; }
        public int UnitID { get; set; }
    }
}
