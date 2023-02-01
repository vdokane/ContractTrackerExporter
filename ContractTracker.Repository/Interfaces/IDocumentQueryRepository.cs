using ContractTracker.Repository.EntityModels;
 
namespace ContractTracker.Repository.Interfaces
{
    public interface IDocumentQueryRepository
    {
        Task<DocumentAttachments> GetOriginalContract(int documentId);
        Task<DocumentAttachments> GetOriginalRedactedContract(int documentId);
    }
}
