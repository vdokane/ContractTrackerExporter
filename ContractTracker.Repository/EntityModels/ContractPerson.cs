using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractTracker.Repository.EntityModels
{
    public class ContractPerson
    {
		[Key]
		public int ContractPersonID { get; set; }
		public int ContractID { get; set; }
		public int? PersonID { get; set; }
		public int PersonTypeID { get; set; }
		 public int UserID { get; set; }
		public DateTime? Timestamp { get; set; }

		public int? AssignedToContractUserId { get; set; }

		[ForeignKey("AssignedToContractUserId")]
		public Users? Users { get; set; } = null!;
 
	}
}
