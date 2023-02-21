
namespace FileExporter.ExportModels
{
    public class DocumentModel
    {
        //What else is needed in the index file?
        public byte[] Attachment { get; set; } = Array.Empty<byte>();
        public string AttachmentFileName { get; set; } = string.Empty;
    }
}
