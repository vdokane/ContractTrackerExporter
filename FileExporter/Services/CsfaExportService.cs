using FileExporter.ExportModels;
using FileExporter.Infrastructure;
using System.Text;

namespace FileExporter.Services
{
    public class CsfaExportService
    {
        public CsfaExportService() { }

        public string BuildCsfaRow(ContractExportModel contractModel)
        {
            if (string.IsNullOrEmpty(contractModel.CSFA))
                return string.Empty;

            var stringBuilder = new StringBuilder();
            stringBuilder.Append(RowConstants.CSFA).Append(FieldDelimiter.Delimiter).Append(contractModel.CSFA);
            return stringBuilder.ToString();

        }
    }
}
