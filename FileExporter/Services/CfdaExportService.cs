using FileExporter.ExportModels;
using FileExporter.Infrastructure;
using System.Text;

namespace FileExporter.Services
{
    public class CfdaExportService
    {
        public CfdaExportService() { }
        public string BuildCfdaRow(ContractExportModel contractModel)
        {
            if (string.IsNullOrEmpty(contractModel.CFDA))
                return string.Empty;

            var stringBuilder = new StringBuilder();
            stringBuilder.Append(RowConstants.CFDA).Append(FieldDelimiter.Delimiter).Append(contractModel.CFDA);
            return stringBuilder.ToString();
        }
    }
}
