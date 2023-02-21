using System;
using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class ContractTypes
    {
        [Key]
        public int ContractTypeId { get; set; }
        public string ContractTypeDescription { get; set; } = string.Empty;
        public string FactsCode { get; set; } = string.Empty;
        public DateTime? EndDate { get; set; }
    }
}
