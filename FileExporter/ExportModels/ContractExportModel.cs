

namespace FileExporter.ExportModels
{
    public class ContractExportModel
    {
        public int ContractId { get; set; }
        public int DocumentID { get; set; }
        public DateTime? ExportDate { get; set; } = null; //But the big questin is, how was the contract app knowing when to set this?
        public string ContractNumberAbbreviated { get; set; } = string.Empty;
        public string ContractNumber { get; set; } = string.Empty;
        public string ContractTypeDescription { get; set; } = string.Empty;

        public string FLAIRContractId { get; set; } = string.Empty;
        public string ProcurementMethodDescription { get; set; } = string.Empty;
        public string StartDate { get; set; } = string.Empty;
        public string ExecuteDate { get; set; } = string.Empty;
        public string AgencyServiceArea { get; set; } = string.Empty; //Tracker doesnt collect this??
        public string AmmendedDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;

        public string Amount { get; set; } = string.Empty;
        public string HourlyRate { get; set; } = string.Empty;
        public string Recurring { get; set; } = string.Empty;
        public string ServiceTypeName { get; set; } = string.Empty;
        public string ServiceTypeShortTitle { get; set; } = string.Empty;
        public string AuthorizedADPayment { get; set; } = string.Empty;
        public string StateTermContractIdentifier { get; set; } = string.Empty;
        public string ExemptionExplanation { get; set; } = string.Empty;
        public string ContractStatutoryAuthority { get; set; } = string.Empty;
        public string GeneralComments { get; set; } = string.Empty;

        public string ContractInvolveFinancialAid { get; set; } = string.Empty;
        public string RecipientTypeCode { get; set; } = string.Empty;
        public string IndirectCostInd { get; set; } = string.Empty;
        public string AdministrativeCostPercentage { get; set; } = string.Empty;
        public string ProvidePeriodicIncrease { get; set; } = string.Empty;
        public string PeriodicIncreasePercentage { get; set; } = string.Empty;
        public string BusinessCaseStudyDone { get; set; } = string.Empty;
        public string BusinessCaseDate { get; set; } = string.Empty;
        public string LegalChallengesProcurement { get; set; } = string.Empty;
        public string LegalChallengeDescription { get; set; } = string.Empty;
        public string PreviouslyDoneByTheState { get; set; } = string.Empty;
        public string ConsideredBackToTheState { get; set; } = string.Empty;
        public string CapitalImprovementsOnStateProperty { get; set; } = string.Empty;
        public string CapitalImprovementDescription { get; set; } = string.Empty;
        public string ValueCapitalImprovements { get; set; } = string.Empty;
        public string ValueUnamortizedCapitalImprovements { get; set; } = string.Empty;
        public string CSFA { get; set; } = string.Empty;
        public string CFDA { get; set; } = string.Empty;
        public string ContractStatus { get; set; } = string.Empty;

        public bool? Confidential { get; set; }

        public int? PublicContractAppContractId { get; set; }

        public string ContractManagerPersonName { get; set; } = string.Empty;
        public string ContractManagerPersonPhoneNumber { get; set; } = string.Empty;
        public string ContractManagerPersonEmail { get; set; } = string.Empty;

        public string VendorType { get; set; } = string.Empty;
        public string VendorNumber { get; set; } = string.Empty;
        public string VendorNumberSequence { get; set; } = string.Empty;

        

    }
}