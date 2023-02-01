using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class ContractChangeAttachments
    {
        [Key]
        public int ContractChangeAttachmentId { get; set; }
        public int ContractChangeId { get; set; }
        public int? RedactedForContractChangeAttachmentId { get; set; }
        public int DocumentAttachmentTypeId { get; set; }
        public byte[] Attachment { get; set; } = null!;
        public string AttachmentFilename { get; set; } = null!;
        public int AddedByUserId { get; set; }
        public DateTime AddedDate { get; set; }
        public int? FACTSDocumentID { get; set; }
        public bool? MarkedForDeletion { get; set; }
        public DateTime? ExportDate { get; set; }
    }
}
