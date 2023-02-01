using System;
using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class ContractPersons
    {
		[Key]
		public int ContractPersonId { get; set; }
		public int ContractId { get; set; }
		public int PersonId { get; set; }
		public int PersonTypeId { get; set; }
		public int CreatedByUserId { get; set; }
		public DateTime CreatedDate { get; set; }
		public virtual Persons Persons { get; set; }
	}
}
