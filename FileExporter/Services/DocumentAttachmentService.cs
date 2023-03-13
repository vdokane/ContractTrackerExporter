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
        //Still TODO, ask the current SME about this on 2023/03/13
        public async Task<List<DocumentModel>> GetAllExportableContractsByDocumentId(int documentId)
        {
            var response = new List<DocumentModel>();

            var contractAttachmentDocument = await documentQueryRepository.GetOriginalContractDocument(documentId);
            if (contractAttachmentDocument == null)
                return response;

            response.Add(MapEntityToModel(contractAttachmentDocument));

            var redactedContractAttachmentDocument = await documentQueryRepository.GetOriginalRedactedContractDocument(documentId);
            if (redactedContractAttachmentDocument == null)
                return response;

            response.Add(MapEntityToModel(redactedContractAttachmentDocument));
            return response;
        }

        public async Task<List<DocumentModel>> GetAllExportableProcurmentsByDocumentId(int documentId)
        {
            var response = new List<DocumentModel>();
            var procumentDocument = await documentQueryRepository.GetProcurementDocument(documentId);
            if (procumentDocument == null)
                return response;

            response.Add(MapEntityToModel(procumentDocument));

            var redactedContractAttachment = await documentQueryRepository.GetProcurementRedactedDocument(documentId);
            if (redactedContractAttachment == null)
                return response;

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
