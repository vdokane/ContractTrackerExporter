using FileExporter.ExportModels;
using FileExporter.Infrastructure;
using System.Text;


namespace FileExporter.Services
{
    public class AttachmentIndexService
    {
        public AttachmentIndexService() { }
        public string BuildFileName(string contractNumber)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(AttachmentRowConstants.Contract).Append("-")
                .Append(ScsOlo.OrgCode).Append("-")
                .Append(contractNumber).Append(".pdf");
                 return stringBuilder.ToString();   


        }
        public string BuildAttachmentIndexRow(AttachmentIndexModel model)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(AttachmentRowConstants.Contract).Append(FieldDelimiter.Delimiter)
                .Append(ScsOlo.OrgCode).Append(FieldDelimiter.Delimiter)
            .Append(model.ShortContractNumber).Append(FieldDelimiter.Delimiter)
            .Append(model.Unknown1).Append(FieldDelimiter.Delimiter)
            .Append(model.FileName).Append(FieldDelimiter.Delimiter)
            .Append(model.Unknown2).Append(FieldDelimiter.Delimiter);

            return stringBuilder.ToString();
        }
    }
}
