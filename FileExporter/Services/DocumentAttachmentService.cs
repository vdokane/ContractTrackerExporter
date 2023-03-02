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
        //TODO, I might need to return one at a time so the file name will be preixed correctly or include the docattachemtnTypeId in the model
        public async Task<List<DocumentModel>> GetAllExportableContractsByDocumentId(int documentId)
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

        public async Task<List<DocumentModel>> GetAllExportableProcurmentsByDocumentId(int documentId)
        {
            var contractAttachmeent = await documentQueryRepository.GetProcurement(documentId);
            var redactedContractAttachment = await documentQueryRepository.GetProcurementRedacted(documentId);

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
