using System.Text;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using FileExporter.ExportModels;
using TrackerFile.Infrastructure.Utilities;

namespace FileExporter.Services
{
    public class BudgetExportService
    {
        private readonly IBudgetQueryRepository budgetQueryRepository;
        public BudgetExportService(IBudgetQueryRepository budgetQueryRepository)
        {
            this.budgetQueryRepository = budgetQueryRepository;
        }

        public async Task<List<BudgetExportModel>> GetBudgetModelsByContractId(int contractId)
        {
            var entities = await budgetQueryRepository.GetBudgetsByContractId(contractId);
            return entities.ConvertAll(x => MapEntityToModel(x));
        }

        public string BuildBudgetRow(BudgetExportModel model)
        {
            /*Record Type BUGT
        Agency Amendment Reference
        Budgetary Amount
        Budgetary Amount Type
        Budgetary Amount Account Code
        Budgetary Amount Fiscal Year Effective Date
        OCA */
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(RowConstants.Budget).Append(FieldDelimiter.Delimiter);
            if (model.ExportDate.HasValue)
                stringBuilder.Append(SaveConstants.Update).Append(FieldDelimiter.Delimiter);
            else
                stringBuilder.Append(SaveConstants.Insert).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.AgencyAmendmentReference.ToString()).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.BudgetaryAmount.ToString()).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.BudgetaryAmountType.ToString()).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.BudgetaryAmountAccountCode.ToString()).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.FiscalYearEffectiveDate.ConvertNullableDateToString()).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.OtherCostAccumulater.ToString()).Append(FieldDelimiter.Delimiter);
            



            //stringBuilder.Append(model.EffectiveBeginDate.Value.ToShortDateString()).Append(FieldDelimiter.Delimiter);
            //stringBuilder.Append(model.EffectiveEndDate.Value.ToShortDateString()).Append(FieldDelimiter.Delimiter);
            //stringBuilder.Append(model.BudgetaryRate.ToString()).Append(FieldDelimiter.Delimiter);  //REALLY?

            return stringBuilder.ToString();
        }

        private BudgetExportModel MapEntityToModel(ContractBudget entity)
        {
            var model = new BudgetExportModel();

            model.BudgetId = entity.ContractBudgetID;
            model.ContractId = entity.ContractID;
            model.FlairCodeId = entity.FLAIRCodeID;
            model.OrgCode = entity.OrgCode.Filter(Santize.Chars); 
            model.EO = entity.EO.Filter(Santize.Chars);
            model.Category = entity.Category.Filter(Santize.Chars);
            model.AgencyAmendmentReference = entity.AgencyAmendmentReference.Filter(Santize.Chars);
            model.BudgetaryAmount = entity.BudgetaryAmount;
            model.BudgetaryAmountType = entity.BudgetaryAmountType.Filter(Santize.Chars);
            model.BudgetaryAmountAccountCode = entity.BudgetaryAmountAccountCode.Filter(Santize.Chars);
            //model.OtherCostAccumulater = entity.OtherCostAccumulater;
            model.FiscalYearEffectiveDate = entity.FiscalYearEffectiveDate;
            model.EffectiveBeginDate = entity.EffectiveBeginDate;
            model.EffectiveEndDate = entity.EffectiveEndDate;
            model.BudgetaryRate = entity.BudgetaryRate.HasValue ? entity.BudgetaryRate.Value : 0;
            model.MarkedForDeletion = entity.MarkedForDeletion;
            model.ExportDate = entity.ExportDate;
            return model;
        }
    }
}
