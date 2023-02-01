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
        public string ContractNum { get; set; } = string.Empty;
        public int? ContractTypeID { get; set; }


        [ForeignKey("ContractTypeID")]
        public ContractTypes ContractTypes { get; set; } = null!;
        //public int? VendorId { get; set; }
        public int? ContractApplicationId { get; set; }
        public string FLAIRContractId { get; set; } = string.Empty;
        public int? ProcurementMethodID { get; set; }

        [ForeignKey("ProcurementMethodID")]
        public ProcurementMethods ProcurementMethods { get; set; } = null!;
        public DateTime? ContractStartDate { get; set; }
        public DateTime? ContractExecuteDate { get; set; }
        public DateTime? ContractAmmendedDate { get; set; } = null;
        public DateTime? ContractEndDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }
        public decimal? HourlyRate { get; set; }
        public bool? Recurring { get; set; }
        public string ServiceType { get; set; } = string.Empty;
        public bool? AuthorizedADPayment { get; set; }
        public string StateTermContractIdentifier { get; set; } = string.Empty;
        public string ExemptionExplanation { get; set; } = string.Empty;
        public string ContractStatutoryAuthority { get; set; } = string.Empty;
        public string GeneralComments { get; set; } = string.Empty;
        public string InternalComments { get; set; } = string.Empty;
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
        public decimal? ValueCapitalImprovements { get; set; }
        public decimal? ValueUnamortizedCapitalImprovements { get; set; }
        public string CSFA { get; set; } = string.Empty;
        public string CFDA { get; set; } = string.Empty;
        public string ContractStatus { get; set; } = string.Empty;
        public string RejectionMessage { get; set; } = string.Empty;
        public string SweepStatus { get; set; } = string.Empty;
        public bool? ExistingContract { get; set; }
        public DateTime? ExportDate { get; set; }
        public bool? MarkedForDeletion { get; set; }
        public bool? Confidential { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public int? PublicContractAppContractId { get; set; }  //What was this for?
        public string VendorNumber { get; set; } = string.Empty;
        public string VendorNumberSequence { get; set; } = string.Empty;
        public string VendorType { get; set; } = string.Empty;
        public string Agency { get; set; } = string.Empty;
        public string ContractTypeCode { get; set; } = string.Empty;
        /* 
	 
	 
 
	 
	 
	[GeneralComments] [varchar](1000) NULL,
	[ContractInvolveFinancialAid] [bit] NULL,
	[RecipientTypeCode] [char](1) NULL,
	[IndirectCostInd] [bit] NULL,
	[AdministrativeCostPercentage] [char](6) NULL,
	[ProvidePeriodicIncrease] [bit] NULL,
	[PeriodicIncreasePercentage] [numeric](5, 2) NULL,
	[BusinessCaseStudyDone] [bit] NULL,
	[BusinessCaseDate] [datetime] NULL,
	[LegalChallengesProcurement] [bit] NULL,
	[LegalChallengeDescription] [varchar](1000) NULL,
	[PreviouslyDoneByTheState] [bit] NULL,
	[ConsideredBackToTheState] [bit] NULL,
	[CapitalImprovementsOnStateProperty] [bit] NULL,
	[CapitalImprovementDescription] [varchar](1000) NULL,
	[ValueCapitalImprovements] [numeric](13, 2) NULL,
	[ValueUnamortizedCapitalImprovements] [numeric](13, 2) NULL,
	[CSFA] [varchar](6) NULL,
	[CFDA] [varchar](6) NULL,
	[DocumentId] [int] NULL,
	[FACTSResubmittedDate] [datetime] NULL,
	 
	[FACTSContractID] [int] NULL,
	[FLAIRContractID] [varchar](10) NULL,
	[ContractStatus] [char](1) NULL,
	[RejectionMessage] [varchar](2000) NULL,
	[VendorType] [char](1) NULL,
	[SweepStatus] [char](1) NULL,
	[ExistingContract] [bit] NULL,
	[ExportDate] [datetime] NULL,
	[MarkedForDeletion] [bit] NULL,
	[Confidential] [bit] NULL */
    }
}
