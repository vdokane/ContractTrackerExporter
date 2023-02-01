using FileExporter.ExportModels;
using FileExporter.Infrastructure;
using System.Text;

namespace FileExporter.Services
{
    public class VendorExportService
    {

        /// <summary>
        /// What was I doing with this? Is vendor part of the contract row? Do I need an export model?
        /// I guess it does: VNDR|F592578012001| I can pull this from contract but once the FK is established I need to have its own repo call
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string BuildVendorRow(ContractExportModel model)
        {
            //If the contract has an export date, we are in update, otherwise insert
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(RowConstants.Vendor)
                .Append(FieldDelimiter.Delimiter);

            stringBuilder.Append(model.VendorType).Append(model.VendorNumber).Append(model.VendorNumberSequence);
            return stringBuilder.ToString();
        }
    }
}
