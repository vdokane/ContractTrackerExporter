using ContractTracker.Repository.Context;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using ContractTracker.Repository.Implementation;
using Microsoft.EntityFrameworkCore;

namespace ContractTracker.Repository.QueryRepositories
{
    public class DocumentAttachmentQueryRepository : IDocumentQueryRepository
    {
        private const int OriginalContractDocAttachmentTypeId = 1;
        private const int OriginalRedactedContractDocAttachmentTypeId = 7;
        private const int ProcurementDocumentsDocAttachmentTypeId = 14;
        private const int ProcurementRedactedDocumentsDocAttachmentTypeId = 17;
  
        private readonly TrackerDbContext context;
        public DocumentAttachmentQueryRepository(IUnitOfWork unitOfWork)
        {
            context = unitOfWork.GetContext();
        }

        public async Task<DocumentAttachments?> GetOriginalContract(int documentId)
        {
            return await GetDocumentAttachment(documentId,  OriginalContractDocAttachmentTypeId);
        }

        public async Task<DocumentAttachments?> GetOriginalRedactedContract(int documentId)
        {
            return await GetDocumentAttachment(documentId, OriginalRedactedContractDocAttachmentTypeId);
        }

        public async Task<DocumentAttachments?> GetProcurement(int documentId)
        {
           return await GetDocumentAttachment(documentId, ProcurementDocumentsDocAttachmentTypeId);
        }

        public async Task<DocumentAttachments?> GetProcurementRedacted(int documentId)
        {
            return await GetDocumentAttachment(documentId, ProcurementRedactedDocumentsDocAttachmentTypeId);
        }

        private async Task<DocumentAttachments?> GetDocumentAttachment(int documentId, int documentAttachmentTypeId)
        {
            return await context.DocumentAttachments
                .Where(x => x.DocumentId == documentId && x.DocAttachmentTypeID == documentAttachmentTypeId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
