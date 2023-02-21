using ContractTracker.Repository.Context;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using ContractTracker.Repository.Implementation;
using Microsoft.EntityFrameworkCore;

namespace ContractTracker.Repository.QueryRepositories
{
    public interface IContractPersonQueryRepository
    {
        Task<Users?> GetContractManagerForContract(int contractId);
    }
    public class ContractPersonQueryRepository : IContractPersonQueryRepository
    {
        public const int ContractManagerPersonTypeId = 1;

        private readonly TrackerDbContext context;
        public ContractPersonQueryRepository(IUnitOfWork unitOfWork)
        {
            context = unitOfWork.GetContext();
        }

        public async Task<Users?> GetContractManagerForContract(int contractId)
        {
            var managerEntity = await context.ContractPerson
                                    .Where(x => x.ContractID == contractId && x.PersonTypeID == ContractManagerPersonTypeId)
                                    .Include(i => i.Users)
                                    .FirstOrDefaultAsync();
            return managerEntity?.Users;
        }
    }
}
