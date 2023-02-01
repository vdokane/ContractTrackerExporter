using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class Units
    {
        [Key]
        public int UnitId { get; set; }
        public string Bureau { get; set; } = string.Empty;
        public string SectionDesc { get; set; } = string.Empty;
        public string Section { get; set; } = string.Empty;
        public string UnitCode { get; set; } = string.Empty;
        public bool? AllUsersCanSubmit { get; set; }
        public bool? PurchaseRequiresSpecialRouting { get; set; }
    }
}
