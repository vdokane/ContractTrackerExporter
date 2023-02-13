using System;
using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class Persons
    {
        [Key]
        public int PersonId { get; set; }
        public int? UnitId { get; set; }
        public string PersonName { get; set; } = string.Empty;
        public string PersonEmail { get; set; } = string.Empty;
        public string PersonPhoneNumber { get; set; } = string.Empty;
        public bool Active { get; set; }
        public int ContactLKID { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
         
    }
}
