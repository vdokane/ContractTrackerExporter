using ContractTracker.Repository.EntityModels;


namespace ContractTracker.Repository.Interfaces
{
    public interface IContractChangeAttachmentRepository
    {
        Task<ContractChangeAttachments?> GetOriginalAmnededContractDocument(int contractChangeId);
        Task<ContractChangeAttachments?> GetRedactedAmendedContractDocument(int contractChangeAttachmentId);
    }
}
