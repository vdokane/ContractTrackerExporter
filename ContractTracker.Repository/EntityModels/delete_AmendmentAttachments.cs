using System;
using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class delete_AmendmentAttachments
    {
        [Key]
        public int AmendmentAttachmentId { get; set; }
        public int AttachmentTypeId { get; set; }
        public byte[] Attachment { get; set; }
        public string AttachmentFilename { get; set; }
        public DateTime InsertDate { get; set; }
        public int UserId { get; set; }
        public int? FACTSDocumentID { get; set; } //--this needs to be renamed (or if I get rid the the Contract app, removed completely)
        public bool? MarkedForDeletion { get; set; }
    }
}
