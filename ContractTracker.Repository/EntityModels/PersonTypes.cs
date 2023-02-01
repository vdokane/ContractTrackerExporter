using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class PersonTypes
    {
        [Key]
        public int PersonTypeId { get; set; }
        public string PersonTypeDescription { get; set; }
        public int IsActive { get; set; }
    }
}
