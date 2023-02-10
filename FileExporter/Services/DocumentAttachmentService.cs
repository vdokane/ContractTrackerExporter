using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using FileExporter.ExportModels;

namespace FileExporter.Services
{
    public class DocumentAttachmentService
    {
        private readonly IDocumentQueryRepository documentQueryRepository;
        public DocumentAttachmentService(IDocumentQueryRepository documentQueryRepository)
        {
            this.documentQueryRepository = documentQueryRepository;
        }

        public async Task<List<DocumentModel>> GetAllDocumentsByDocumentId(int documentId)
        {
            var contractAttachmeent = await documentQueryRepository.GetOriginalContract(documentId);
            var redactedContractAttachment = await documentQueryRepository.GetOriginalRedactedContract(documentId);

            var response = new List<DocumentModel>();
            if (contractAttachmeent != null)
                response.Add(MapEntityToModel(contractAttachmeent));
            if (redactedContractAttachment != null)
                response.Add(MapEntityToModel(redactedContractAttachment));
            return response;
        }

        private DocumentModel MapEntityToModel(DocumentAttachments? entity)
        {
            if (entity == null)
                return null;
            var model = new DocumentModel();
            model.Attachment = entity.Attachment;
            model.AttachmentFileName = entity.attachmentfilename;
            return model;
        }
    }
}
