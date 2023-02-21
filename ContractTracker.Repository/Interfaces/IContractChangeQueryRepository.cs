using ContractTracker.Repository.EntityModels;

namespace ContractTracker.Repository.Interfaces
{
    public interface IContractChangeQueryRepository
    {
        Task<List<ContractChange>> GetChangesByContractId(int contractId);
    }
}
