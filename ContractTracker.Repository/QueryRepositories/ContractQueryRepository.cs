using ContractTracker.Repository.Context;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using ContractTracker.Repository.Implementation;

namespace ContractTracker.Repository.QueryRepositories
{
    public class ContractQueryRepository : IContractQueryRepository
    {
        private readonly TrackerDbContext context;
        public ContractQueryRepository(IUnitOfWork unitOfWork)
        {
            context = unitOfWork.GetContext();
        }

        public async Task<List<Contracts>> GetAllContractsReadyToBeSubmitted(DateTime sweepDate)
        {
            return null;
            //TODO, join from contract, to document, to document status type where "approve by GS" is in the past 24 hour window
        }
    }
}
