using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class ServiceTypes
    {
        [Key]
        public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; } = string.Empty;
        public string ShortTitle { get; set; } = string.Empty;
        public int ContractAppServiceTypeID { get; set; }
    }
}
