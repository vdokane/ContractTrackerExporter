using ContractTracker.Repository.Context;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using ContractTracker.Repository.Implementation;
using Microsoft.EntityFrameworkCore;

namespace ContractTracker.Repository.QueryRepositories
{
    public interface IContractPersonQueryRepository
    {
        Task<Persons> GetContractManagerForContract(int contractId);
    }
    public class ContractPersonQueryRepository : IContractPersonQueryRepository
    {
        public const int ContractManagerPersonTypeId = 1;

        private readonly TrackerDbContext context;
        public ContractPersonQueryRepository(IUnitOfWork unitOfWork)
        {
            context = unitOfWork.GetContext();
        }

        public async Task<Persons> GetContractManagerForContract(int contractId)
        {
            var managerEntity = await context.ContractPersons
                                    .Where(x => x.ContractId == contractId && x.PersonTypeId == ContractManagerPersonTypeId)
                                    .Include(i => i.Persons)
                                    .FirstOrDefaultAsync();
            return managerEntity?.Persons;
        }
    }
}
