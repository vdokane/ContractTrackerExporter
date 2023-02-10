using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractTracker.Repository.EntityModels
{
    public class Contracts
    {
        [Key]
        public int ContractID { get; set; }
        public int DocumentID { get; set; }
        public DateTime? ContractStartDate { get; set; }
        public DateTime? ContractExecuteDate { get; set; }
        public DateTime? ContractAmmendedDate { get; set; } = null;

        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }
        public DateTime? TimeStamp { get; set; }
        public DateTime? ContractEndDate { get; set; }
        public bool? Recurring { get; set; }
        public string VendorName { get; set; } = string.Empty;
        public string ServiceType { get; set; } = string.Empty;
        public string ContractNum { get; set; } = string.Empty;
        public decimal? HourlyRate { get; set; }
        public string Agency { get; set; } = string.Empty;
        public string ContractTypeCode { get; set; } = string.Empty;
        public bool? AuthorizedADPayment { get; set; }
        public string StateTermContractIdentifier { get; set; } = string.Empty;
        public string ExemptionExplanation { get; set; } = string.Empty;
        public string ContractStatutoryAuthority { get; set; } = string.Empty;
        public string GeneralComments { get; set; } = string.Empty;
        public bool? ContractInvolveFinancialAid { get; set; }
        public string RecipientTypeCode { get; set; } = string.Empty;
        public bool? IndirectCostInd { get; set; }
        public string AdministrativeCostPercentage { get; set; } = string.Empty;
        public bool? ProvidePeriodicIncrease { get; set; }
        public decimal? PeriodicIncreasePercentage { get; set; }
        public bool? BusinessCaseStudyDone { get; set; }
        public DateTime? BusinessCaseDate { get; set; }
        public bool? LegalChallengesProcurement { get; set; }
        public string LegalChallengeDescription { get; set; } = string.Empty;
        public bool? PreviouslyDoneByTheState { get; set; }
        public bool? ConsideredBackToTheState { get; set; }
        public bool? CapitalImprovementsOnStateProperty { get; set; }
        public string CapitalImprovementDescription { get; set; } = string.Empty;
        public decimal ValueCapitalImprovements { get; set; }
        public decimal ValueUnamortizedCapitalImprovements { get; set; }
        public string CSFA { get; set; } = string.Empty;
        public string CFDA { get; set; } = string.Empty;
        public bool? DocumentId { get; set; }
        public DateTime? FACTSResubmittedDate { get; set; }
        public string VendorNumber { get; set; } = string.Empty;
        public string VendorNumberSequence { get; set; } = string.Empty;
        public int? FACTSContractID { get; set; }
        public string FLAIRContractID { get; set; } = string.Empty;
        public string ContractStatus { get; set; } = string.Empty;
        public string RejectionMessage { get; set; } = string.Empty;
        public string VendorType { get; set; } = string.Empty;
        public string SweepStatus { get; set; } = string.Empty;
        public bool? ExistingContract { get; set; }
        public DateTime? ExportDate { get; set; }
        public bool? MarkedForDeletion { get; set; }
        public bool? Confidential { get; set; }
        public string InternalComments { get; set; } = string.Empty;
        public int? ProcurementMethodID { get; set; }
        [ForeignKey("ProcurementMethodID")]
        public ProcurementMethods ProcurementMethods { get; set; } = null!;
        public int? SoleSourcePurchaseId { get; set; }


    }
}
