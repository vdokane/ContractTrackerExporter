using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class ProcurementMethods
    {
        [Key]
        public int ProcurementMethodId { get; set; }
        public string Code { get; set; }
        public string ProcurementMethodDescription { get; set; }
        public string Exemption { get; set; }
        public bool ProcurementDocumentRequired { get; set; }
        public bool Active { get; set; }
    }
}
