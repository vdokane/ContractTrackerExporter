using ContractTracker.Repository.Context;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Implementation;
using ContractTracker.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace ContractTracker.Repository.QueryRepositories
{
    public class ContractChangeAttachmentRepository : IContractChangeAttachmentRepository
    {
 
        private const int AmendmentContractDocumentAttachmentTypeId = 13;
        private readonly TrackerDbContext context;
        public ContractChangeAttachmentRepository(IUnitOfWork unitOfWork)
        {
            context = unitOfWork.GetContext();
        }

        public async Task<ContractChangeAttachments?> GetOriginalAmnededContractDocument(int contractChangeId)
        {
            return await context.ContractChangeAttachments
                .Where(x => x.ContractChangeId == contractChangeId && x.DocumentAttachmentTypeId == AmendmentContractDocumentAttachmentTypeId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<ContractChangeAttachments?> GetRedactedAmendedContractDocument(int contractChangeAttachmentId)
        {
            return await context.ContractChangeAttachments
                .Where(x => x.RedactedForContractChangeAttachmentId == contractChangeAttachmentId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
          
    }
}
