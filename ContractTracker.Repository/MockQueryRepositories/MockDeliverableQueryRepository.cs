using ContractTracker.Repository.Context;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using ContractTracker.Repository.Implementation;

namespace ContractTracker.Repository.MockQueryRepositories
{
    public class MockDeliverableQueryRepository : IDeliverableQueryRepository
    {
        public Task<List<ContractDeliverables>> GetDeliverablesByContractId(int contractId)
        {
            throw new NotImplementedException();
        }
    }
}
