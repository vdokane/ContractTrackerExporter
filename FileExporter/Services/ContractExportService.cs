using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using ContractTracker.Repository.QueryRepositories;
using FileExporter.ExportModels;
using FileExporter.Infrastructure;

namespace FileExporter.Services
{
    public class ContractExportService
    {
        private readonly IContractQueryRepository contractQueryRepository;
        private readonly IContractPersonQueryRepository contractPersonQueryRepository;
        private readonly IContractTrackingHistoryQueryRepository contractTrackingHistoryQueryRepository;
        public ContractExportService(IContractQueryRepository contractQueryRepository,
                                    IContractPersonQueryRepository contractPersonQueryRepository,
                                    IContractTrackingHistoryQueryRepository contractTrackingHistoryQueryRepository)
        {
            this.contractQueryRepository = contractQueryRepository;
            this.contractPersonQueryRepository = contractPersonQueryRepository;
            this.contractTrackingHistoryQueryRepository = contractTrackingHistoryQueryRepository;
        }

        //Quesstions for Lucy- What criteria to make a contract get in the FTP file
        //UPD vs INS?
        //FileFormats
        //How does Export Date get set? Like, how do we know a contract is finally uploaded correctly
        public async Task<List<ContractExportModel>> GetContractsForExporting(DateTime sweepDate)
        {
            var allContractIds = await contractTrackingHistoryQueryRepository.GetAllContractIdsReadyForExporting(sweepDate);
            var allEntities = await contractQueryRepository.GetAllContractsReadyToBeSubmitted(allContractIds);

            var response = new List<ContractExportModel>();
            foreach (var entity in allEntities)
            {
                var model = await MapEntityToModel(entity);
                response.Add(model);
            }
            return response;
        }

        /*
         * FLAIR Agency Identifier (OLO)
FLAIR Contract/Grant Disbursement Agreement Identifier (FLAIR ID)
Short Title
Long Title
        Agency Assigned Contract/Grant Disbursement Agreement Identifier .ContractId
Contract/Grant Disbursement Agreement’s Type = "sc"
Contract/Grant Disbursement Agreement’s Status
Original Contract/Grant Disbursement Agreement Amount

Contract/Grant Disbursement Agreement’s Date of Execution    YYYY-MM-DD

Contract/Grant Disbursement Agreement’s Beginning Date
Contract/Grant Disbursement Agreements’ Original Ending Date
Agency Service Area
Agency Contract/Grant Disbursement Agreement Manager’s Name
Agency Contract/Grant Disbursement Agreement Manager’s Phone Number
Agency Contract/Grant Disbursement Agreement Manager‘s e-mail address
Authorized Advance Payment
Contract/Grant Disbursement Agreement’s Method of Procurement
State Term Contract Identifier
Agency Reference Number
Contract/Grant Disbursement Agreement’s Exemption Explanation
Contract/Grant Disbursement Agreement’s Statutory Authority
General Description of the Contract/Grant Disbursement Agreement
Contract/Grant Disbursement Agreement Involves State or Federal Financial Aid
Recipient Type
Provide for Administrative Cost
Administrative Cost Percentage
Provide for Periodic Increase
Periodic Increase Percentage
Business Case Study Done
Business Case Date
Legal Challenges to Procurement
Legal Challenge Description
Was the Contracted Functions Previously Done by the State
Was the Contracted Functions Considered for Insourcing back to the State
Did the Vendor Make Capital Improvements on State Property
Capital Improvements Description
Value of Capital Improvements
Value of Unamortized Capital Improvements
Do not publish this contract/grant disbursement agreement on the FACTS website
New Ending Date

         */
        public string BuildContractRow(ContractExportModel model)
        {
            //If the contract has an export date, we are in update, otherwise insert
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(RowConstants.Contract).Append(FieldDelimiter.Delimiter);
            if (model.ExportDate.HasValue)
                stringBuilder.Append(SaveConstants.Update).Append(FieldDelimiter.Delimiter);
            else
                stringBuilder.Append(SaveConstants.Insert).Append(FieldDelimiter.Delimiter);

            stringBuilder.Append(ScsOlo.OrgCode).Append(FieldDelimiter.Delimiter);

            stringBuilder.Append(model.ContractNumberAbbreviated).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.ServiceTypeName).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.ServiceTypeShortTitle).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.ContractId.ToString()).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append("SC").Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.ContractStatus).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.Amount).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.ExecuteDate).Append(FieldDelimiter.Delimiter);
            //Left off here..I have no icdea what the order is!! 2023/01/02


            stringBuilder.Append(model.BusinessCaseDate).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.LegalChallengeDescription).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.AdministrativeCostPercentage).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.AmmendedDate).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.EndDate).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.AuthorizedADPayment).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.BusinessCaseDate).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.BusinessCaseStudyDone).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.CapitalImprovementDescription).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.CapitalImprovementsOnStateProperty).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.CFDA).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.CSFA).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.Confidential).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.ConsideredBackToTheState).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.ContractInvolveFinancialAid).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.ContractManagerPersonEmail).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.ContractManagerPersonName).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.ContractManagerPersonPhoneNumber).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.ContractStatus).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.ContractStatutoryAuthority).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.ContractTypeDescription).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.FLAIRContractId).Append(FieldDelimiter.Delimiter); //Need a JOIN or something, I think?
            stringBuilder.Append(model.GeneralComments).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.HourlyRate).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.IndirectCostInd).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.LegalChallengeDescription).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.LegalChallengesProcurement).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.PeriodicIncreasePercentage).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.PreviouslyDoneByTheState).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.ProcurementMethodDescription).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.ProvidePeriodicIncrease).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.PublicContractAppContractId).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.RecipientTypeCode).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.Recurring).Append(FieldDelimiter.Delimiter);
             
            stringBuilder.Append(model.StartDate).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.StateTermContractIdentifier).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.ValueCapitalImprovements).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.ValueUnamortizedCapitalImprovements).Append(FieldDelimiter.Delimiter);


            return stringBuilder.ToString();
        }

        private async Task<ContractExportModel> MapEntityToModel(Contracts entity)
        {
            var model = new ContractExportModel();
            model.ContractId = entity.ContractID;
            
            //todo move out of here
            var contractManager = await contractPersonQueryRepository.GetContractManagerForContract(entity.ContractID);
            if (contractManager != null)
            {
                model.ContractManagerPersonName = contractManager.UserName.Filter(Santize.Chars);
                model.ContractManagerPersonPhoneNumber = contractManager.OfficeTelephone.Filter(Santize.Chars);
                model.ContractManagerPersonEmail = contractManager.UserEmail.Filter(Santize.Chars);
            }
            model.ExportDate = entity.ExportDate;
            model.AdministrativeCostPercentage = entity.AdministrativeCostPercentage.Filter(Santize.Chars);
            model.Amount = entity.Amount.HasValue ? entity.Amount.Value.ToString().Filter(Santize.Chars) : string.Empty;
            model.AuthorizedADPayment = entity.AuthorizedADPayment.ConvertNullableBoolToYesNo().Filter(Santize.Chars);
            model.BusinessCaseDate = entity.BusinessCaseDate.ConvertNullableDateToString().Filter(Santize.Chars);
            model.BusinessCaseStudyDone = entity.BusinessCaseStudyDone.ConvertNullableBoolToYesNo().Filter(Santize.Chars);
            model.CapitalImprovementDescription = entity.CapitalImprovementDescription.Filter(Santize.Chars);
            model.CapitalImprovementsOnStateProperty = entity.CapitalImprovementsOnStateProperty.ConvertNullableBoolToYesNo().Filter(Santize.Chars);
            model.CFDA = entity.CFDA.Filter(Santize.Chars);
            //Confidential?
            model.CSFA = entity.CSFA.Filter(Santize.Chars);
            model.ContractStatus = entity.ContractStatus.Filter(Santize.Chars);  //Maybe?
            model.ContractStatutoryAuthority = entity.ContractStatutoryAuthority.Filter(Santize.Chars);
            // model.ContractTypeDescription = entity.ContractTypes.ContractTypeDescription.Filter(Santize.Chars);
            model.ContractNumberAbbreviated = FormatContractNumber(entity.ContractNum).Filter(Santize.Chars);
            model.ContractNumber = entity.ContractNum.Filter(Santize.Chars);
            model.ContractStatus = entity.ContractStatus.Filter(Santize.Chars);
            model.ContractStatutoryAuthority = entity.ContractStatutoryAuthority.Filter(Santize.Chars);
            model.DocumentID = entity.DocumentID.Value;
            model.EndDate = entity.ContractEndDate.ConvertNullableDateToString().Filter(Santize.Chars);
            model.ExecuteDate = entity.ContractExecuteDate.ConvertNullableDateToString().Filter(Santize.Chars);
            model.ExemptionExplanation = entity.ExemptionExplanation.Filter(Santize.Chars); //Does thhis get exported?
            model.GeneralComments = entity.GeneralComments.Filter(Santize.Chars);  //Again, does this get exported? 
            model.HourlyRate = entity.HourlyRate.ConvertNullableDecimalToString().Filter(Santize.Chars);
            model.IndirectCostInd = entity.IndirectCostInd.ConvertNullableBoolToYesNo().Filter(Santize.Chars);
            model.LegalChallengeDescription = entity.LegalChallengeDescription.Filter(Santize.Chars);
            model.LegalChallengesProcurement = entity.LegalChallengesProcurement.ConvertNullableBoolToYesNo().Filter(Santize.Chars);
            model.PeriodicIncreasePercentage = entity.PeriodicIncreasePercentage.ConvertNullableDecimalToString().Filter(Santize.Chars);
            model.PreviouslyDoneByTheState = entity.PreviouslyDoneByTheState.ConvertNullableBoolToYesNo().Filter(Santize.Chars);
            if (entity.MethodOfProcurementCodes != null)
                model.ProcurementMethodDescription = entity.MethodOfProcurementCodes.Description.Filter(Santize.Chars);
            model.ProvidePeriodicIncrease = entity.ProvidePeriodicIncrease.ConvertNullableBoolToYesNo().Filter(Santize.Chars);
            model.RecipientTypeCode = entity.RecipientTypeCode.Filter(Santize.Chars);
            model.Recurring = entity.Recurring.ConvertNullableBoolToYesNo().Filter(Santize.Chars); //Do we export

           
            if (entity.ServiceTypes != null)
            {
                model.ServiceTypeName = entity.ServiceTypes.ServiceTypeName.Filter(Santize.Chars);
                model.ServiceTypeShortTitle = entity.ServiceTypes.ShortTitle.Filter(Santize.Chars);
            }
            
            
            model.StartDate = entity.ContractStartDate.ConvertNullableDateToString().Filter(Santize.Chars);
            model.StateTermContractIdentifier = entity.StateTermContractIdentifier.Filter(Santize.Chars);
            model.ValueCapitalImprovements = entity.ValueCapitalImprovements.ConvertNullableDecimalToString().Filter(Santize.Chars);
            model.ValueUnamortizedCapitalImprovements = entity.ValueUnamortizedCapitalImprovements.ConvertNullableDecimalToString().Filter(Santize.Chars);
            //TODO, at a certain point this needs to be a join
            model.VendorType = entity.VendorType;
            model.VendorNumber = entity.VendorNumber;
            model.VendorNumberSequence = entity.VendorNumberSequence;

            return model;
        }

        
        private string FormatContractNumber(string contractNumber)
        {
            //TODO, remove the first two characters
            return contractNumber;
        }
    }
}
