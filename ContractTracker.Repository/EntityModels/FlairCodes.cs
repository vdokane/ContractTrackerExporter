using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class FlairCodes
    {
        [Key]
        public int FlairCodeId { get; set; }
        public string Org { get; set; }
        public string EO { get; set; }
        public string Category { get; set; }
        public string FlairAccountCode { get; set; }
    }
}
