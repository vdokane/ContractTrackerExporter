using ContractTracker.Repository.EntityModels;
 
namespace ContractTracker.Repository.Interfaces
{
    public interface IDocumentQueryRepository
    {
        Task<DocumentAttachments?> GetOriginalContractDocument(int documentId);
        Task<DocumentAttachments?> GetOriginalRedactedContractDocument(int documentId);
        Task<DocumentAttachments?> GetProcurementDocument(int documentId);
        Task<DocumentAttachments?> GetProcurementRedactedDocument(int documentId);
    }
}
