using ContractTracker.Repository.EntityModels;

namespace ContractTracker.Repository.Interfaces
{
    public interface IDeliverableQueryRepository
    {
        Task<List<Deliverables>> GetDeliverablesByContractId(int contractId);

    }
}
