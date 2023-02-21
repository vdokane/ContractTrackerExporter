
namespace FileExporter.ExportModels
{
    public class ContractChangeAttachmentExportModel
    {
        public byte[] Attachment { get; set; } = null!;
        public string AttachmentFilename { get; set; } = null!;
        public DateTime AddedDate { get; set; }
        public DateTime? ExportDate { get; set; }
        public int ContractChangeAttachmentId { get; set; }
    }
}
