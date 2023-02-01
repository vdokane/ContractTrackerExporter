using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class AttachmentTypes
    {
        [Key]
        public int AttachmentTypeId { get; set; }
        public string AttachmentTypeDescription { get; set; }
        public bool? IsActive { get; set; }
        public bool? OSCAOnly { get; set; }
    }
}
