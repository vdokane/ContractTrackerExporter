using System.Text;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using FileExporter.ExportModels;
using FileExporter.Infrastructure;

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
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(RowConstants.Budget).Append(FieldDelimiter.Delimiter);
            if (model.ExportDate.HasValue)
                stringBuilder.Append(SaveConstants.Update).Append(FieldDelimiter.Delimiter);
            else
                stringBuilder.Append(SaveConstants.Insert).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.BudgetaryAmount.ToString()).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.AgencyAmendmentReference.ToString()).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.BudgetaryAmountType.ToString()).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.BudgetaryAmountAccountCode.ToString()).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.OtherCostAccumulater.ToString()).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.EffectiveBeginDate.Value.ToShortDateString()).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.EffectiveEndDate.Value.ToShortDateString()).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.BudgetaryRate.ToString()).Append(FieldDelimiter.Delimiter);
                         
            return stringBuilder.ToString();
        }

        private BudgetExportModel MapEntityToModel(ContractBudget entity)
        {
            var model = new BudgetExportModel();

            model.BudgetId = entity.ContractBudgetID;
            model.ContractId = entity.ContractID;
            model.FlairCodeId = entity.FLAIRCodeID;
            model.OrgCode = entity.OrgCode;
            model.EO = entity.EO;
            model.Category = entity.Category;
            model.AgencyAmendmentReference = entity.AgencyAmendmentReference;
            model.BudgetaryAmount = entity.BudgetaryAmount;
            model.BudgetaryAmountType = entity.BudgetaryAmountType;
            model.BudgetaryAmountAccountCode = entity.BudgetaryAmountAccountCode;
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
