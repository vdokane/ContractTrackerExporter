using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using FileExporter.ExportModels;
using FileExporter.Infrastructure;
using System.Text;

namespace FileExporter.Services
{
    public class ContractChangeExportService
    {
        private readonly IContractChangeQueryRepository changeQueryRepository;
        public ContractChangeExportService(IContractChangeQueryRepository changeQueryRepository)
        {
            this.changeQueryRepository = changeQueryRepository; 
        }
        public async Task<List<ContractChangeExportModel>> GetChangesForExport(int contractId)
        {
            var allEntities = await changeQueryRepository.GetChangesByContractId(contractId);
            return allEntities.ConvertAll(x => MapEntityToModel(x));
        }

        public string BuildContractChangeRow(ContractChangeExportModel model)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(RowConstants.Change).Append(FieldDelimiter.Delimiter);

            if (model.ExportDate.HasValue)
                stringBuilder.Append(SaveConstants.Update).Append(FieldDelimiter.Delimiter);
            else
                stringBuilder.Append(SaveConstants.Insert).Append(FieldDelimiter.Delimiter);
           
            stringBuilder.Append(model.Action.ToString()).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.AmendmentAmount.ToString()).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.AmendmentEffectiveDate.ToShortTimeString()).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.AmendmentReference.ToString()).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.ChangeDateExecuted.ToShortDateString()).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.ChangeDescription.ToString()).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.ContractChangeType.ToString()).Append(FieldDelimiter.Delimiter);
            stringBuilder.Append(model.NewEndingDate.ToString()).Append(FieldDelimiter.Delimiter);

            return stringBuilder.ToString();
        }
        private ContractChangeExportModel MapEntityToModel(ContractChange entity)
        {
            var model = new ContractChangeExportModel();
            model.Action = entity.Action.Filter(Santize.Chars); 
            model.AmendmentAmount = entity.AmendmentAmount;
            model.AmendmentEffectiveDate = entity.AmendmentEffectiveDate;
            model.AmendmentReference = entity.AmendmentReference.Filter(Santize.Chars);
            model.ChangeDateExecuted = entity.ChangeDateExecuted;
            model.ChangeDescription = entity.ChangeDescription.Filter(Santize.Chars);
            model.ContractChangeID = entity.ContractChangeID;
            model.ContractChangeType = entity.ContractChangeType.Filter(Santize.Chars);
            model.ContractID = entity.ContractID;
            model.ExportDate = entity.ExportDate;
            model.NewEndingDate = entity.NewEndingDate;
            
            return model; 
        }
    }
}
