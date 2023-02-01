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
        public ContractExportService(IContractQueryRepository contractQueryRepository,
                                    IContractPersonQueryRepository contractPersonQueryRepository)
        {
            this.contractQueryRepository = contractQueryRepository;
            this.contractPersonQueryRepository = contractPersonQueryRepository;
        }

        //Quesstions for Lucy- What criteria to make a contract get in the FTP file
        //UPD vs INS?
        //FileFormats
        //How does Export Date get set? Like, how do we know a contract is finally uploaded correctly
        public async Task<List<ContractExportModel>> GetContractsForExporting(DateTime sweepDate)
        {
            var allEntities = await contractQueryRepository.GetAllContractsReadyToBeSubmitted(sweepDate);

            var response = new List<ContractExportModel>();
            foreach (var entity in allEntities)
            {
                var model = await MapEntityToModel(entity);
                response.Add(model);
            }
            return response;
        }

        //TODO, get format
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

            //Left off here..I have no icdea what the order is!! 2023/01/02

            stringBuilder.Append(model.Amount).Append(FieldDelimiter.Delimiter);
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
            stringBuilder.Append(model.ServiceType).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.StartDate).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.StateTermContractIdentifier).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.ValueCapitalImprovements).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.ValueUnamortizedCapitalImprovements).Append(FieldDelimiter.Delimiter);


            return stringBuilder.ToString();
        }

        private async Task<ContractExportModel> MapEntityToModel(Contracts entity)
        {
            var model = new ContractExportModel();

            var contractManager = await contractPersonQueryRepository.GetContractManagerForContract(entity.ContractID);
            if (contractManager != null)
            {
                model.ContractManagerPersonName = contractManager.PersonName.Filter(Santize.Chars);
                model.ContractManagerPersonPhoneNumber = contractManager.PersonPhoneNumber.Filter(Santize.Chars);
                model.ContractManagerPersonEmail = contractManager.PersonEmail.Filter(Santize.Chars);
            }
            model.ExportDate = entity.ExportDate;
            model.AdministrativeCostPercentage = entity.AdministrativeCostPercentage.Filter(Santize.Chars);
            model.Amount = entity.Amount.HasValue ? entity.Amount.Value.ToString().Filter(Santize.Chars) : string.Empty;
            model.AuthorizedADPayment = ConvertNullableBoolToYesNo(entity.AuthorizedADPayment).Filter(Santize.Chars);
            model.BusinessCaseDate = ConvertNullableDateToString(entity.BusinessCaseDate).Filter(Santize.Chars);
            model.BusinessCaseStudyDone = ConvertNullableBoolToYesNo(entity.BusinessCaseStudyDone).Filter(Santize.Chars);
            model.CapitalImprovementDescription = entity.CapitalImprovementDescription.Filter(Santize.Chars);
            model.CapitalImprovementsOnStateProperty = ConvertNullableBoolToYesNo(entity.CapitalImprovementsOnStateProperty).Filter(Santize.Chars);
            model.CFDA = entity.CFDA.Filter(Santize.Chars);
            //Confidential?
            model.CSFA = entity.CSFA.Filter(Santize.Chars);
            model.ContractStatus = entity.ContractStatus.Filter(Santize.Chars);  //Maybe?
            model.ContractStatutoryAuthority = entity.ContractStatutoryAuthority.Filter(Santize.Chars);
            model.ContractTypeDescription = entity.ContractTypes.ContractTypeDescription.Filter(Santize.Chars);
            model.ContractNumberAbbreviated = FormatContractNumber(entity.ContractNum).Filter(Santize.Chars);
            model.ContractNumber = entity.ContractNum.Filter(Santize.Chars);
            model.ContractStatus = entity.ContractStatus.Filter(Santize.Chars);
            model.ContractStatutoryAuthority = entity.ContractStatutoryAuthority.Filter(Santize.Chars);
            model.DocumentID = entity.DocumentID;
            model.EndDate = ConvertNullableDateToString(entity.ContractEndDate).Filter(Santize.Chars);
            model.ExecuteDate = ConvertNullableDateToString(entity.ContractExecuteDate).Filter(Santize.Chars);
            model.ExemptionExplanation = entity.ExemptionExplanation.Filter(Santize.Chars); //Does thhis get exported?
            model.GeneralComments = entity.GeneralComments.Filter(Santize.Chars);  //Again, does this get exported? 
            model.HourlyRate = ConvertNullableDecimalToString(entity.HourlyRate).Filter(Santize.Chars);
            model.IndirectCostInd = ConvertNullableBoolToYesNo(entity.IndirectCostInd).Filter(Santize.Chars);
            model.LegalChallengeDescription = entity.LegalChallengeDescription.Filter(Santize.Chars);
            model.LegalChallengesProcurement = ConvertNullableBoolToYesNo(entity.LegalChallengesProcurement).Filter(Santize.Chars);
            model.PeriodicIncreasePercentage = ConvertNullableDecimalToString(entity.PeriodicIncreasePercentage).Filter(Santize.Chars);
            model.PreviouslyDoneByTheState = ConvertNullableBoolToYesNo(entity.PreviouslyDoneByTheState).Filter(Santize.Chars);
            model.ProcurementMethodDescription = entity.ProcurementMethods.ProcurementMethodDescription.Filter(Santize.Chars);
            model.ProvidePeriodicIncrease = ConvertNullableBoolToYesNo(entity.ProvidePeriodicIncrease).Filter(Santize.Chars);
            model.RecipientTypeCode = entity.RecipientTypeCode.Filter(Santize.Chars);
            model.Recurring = ConvertNullableBoolToYesNo(entity.Recurring).Filter(Santize.Chars); //Do we export
            model.ServiceType = entity.ServiceType.Filter(Santize.Chars);
            model.StartDate = ConvertNullableDateToString(entity.ContractStartDate).Filter(Santize.Chars);
            model.StateTermContractIdentifier = entity.StateTermContractIdentifier.Filter(Santize.Chars);
            model.ValueCapitalImprovements = ConvertNullableDecimalToString(entity.ValueCapitalImprovements).Filter(Santize.Chars);
            model.ValueUnamortizedCapitalImprovements = ConvertNullableDecimalToString(entity.ValueUnamortizedCapitalImprovements).Filter(Santize.Chars);
            //TODO, at a certain point this needs to be a join
            model.VendorType = entity.VendorType;
            model.VendorNumber = entity.VendorNumber;
            model.VendorNumberSequence = entity.VendorNumberSequence;

            return model;
        }

        private string ConvertNullableBoolToYesNo(bool? property)
        {
            return property.HasValue ? (property.Value ? "Y" : "N") : string.Empty;  //I think or does it default to no?
        }

        private string ConvertNullableDateToString(DateTime? property)
        {
            return property.HasValue ? property.Value.ToShortDateString() : string.Empty;
        }

        private string ConvertNullableDecimalToString(decimal? property)
        {
            return property.HasValue ? property.Value.ToString() : string.Empty;
        }
        private string FormatContractNumber(string contractNumber)
        {
            //TODO, remove the first two characters
            return contractNumber;
        }
    }
}
