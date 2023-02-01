
using ContractTracker.Repository.EntityModels;

namespace ContractTracker.Repository.Interfaces
{
    public interface IContractQueryRepository
    {
        public Task<List<Contracts>> GetAllContractsReadyToBeSubmitted(DateTime sweepDate);
         
    }
}
