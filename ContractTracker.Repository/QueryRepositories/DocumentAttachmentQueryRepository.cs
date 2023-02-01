using ContractTracker.Repository.Context;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContractTracker.Repository.Implementation;
using Microsoft.EntityFrameworkCore;

namespace ContractTracker.Repository.QueryRepositories
{
    public class DocumentAttachmentQueryRepository : IDocumentQueryRepository
    {
        private const int OriginalContractDocAttachmentTypeId = 1;
        private const int OriginalRedactedContractDocAttachmentTypeId = 7;
        private readonly TrackerDbContext context;
        public DocumentAttachmentQueryRepository(IUnitOfWork unitOfWork)
        {
            context = unitOfWork.GetContext();
        }

        public async Task<DocumentAttachments> GetOriginalContract(int documentId)
        {
            return await context.DocumentAttachments
                .Where(x => x.DocumentId == documentId && x.DocAttachmentTypeID == OriginalContractDocAttachmentTypeId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<DocumentAttachments> GetOriginalRedactedContract(int documentId)
        {
            return await context.DocumentAttachments
                .Where(x => x.DocumentId == documentId && x.DocAttachmentTypeID == OriginalRedactedContractDocAttachmentTypeId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
