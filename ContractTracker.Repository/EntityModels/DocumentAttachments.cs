using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
	public class DocumentAttachments
	{
		[Key]
		public int DocumentAttachmentId { get; set; }
		public int DocumentId { get; set; }
		public byte[]  Attachment   {get;set;} =Array.Empty<byte>();
		public DateTime TimeSTamp { get; set; }
		public int LastUpdater { get; set; }
		public string attachmentfilename { get; set; } = string.Empty;
		public int DocAttachmentTypeID { get; set; }	
		public int? FACTSDocumentID { get; set; }
		public bool? markedForDeletion { get; set; }
		public DateTime? ExportDate { get; set; }

	}
}
