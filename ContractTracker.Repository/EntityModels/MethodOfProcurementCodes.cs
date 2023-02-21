using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class MethodOfProcurementCodes
    {
        [Key]
        public int ProcurementMethodID { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Exemption { get; set; } = string.Empty;
        public bool ProcurementDocumentRequired { get; set; }
        public bool Active { get; set; }

        public bool? SoleSourceApplicable { get; set; }
        
    }
}
