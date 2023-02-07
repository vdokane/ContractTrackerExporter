using ContractTracker.Repository.Context;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using ContractTracker.Repository.Implementation;
using Microsoft.EntityFrameworkCore;

namespace ContractTracker.Repository.QueryRepositories
{
    public class ContractQueryRepository : IContractQueryRepository
    {
        private readonly TrackerDbContext context;
        private const int ApprovedByGeneralServicesTrackingHistoryStepId = 3;
        public ContractQueryRepository(IUnitOfWork unitOfWork)
        {
            context = unitOfWork.GetContext();
        }

        public async Task<List<Contracts>> GetAllContractsReadyToBeSubmitted(DateTime sweepDate)
        {
            var allContractIds = await context.ContractTrackingHistory
                .Where(x => x.ContractTrackingStepsID == ApprovedByGeneralServicesTrackingHistoryStepId &&
                EF.Functions.DateDiffDay(x.TimeStamp, sweepDate) == 1 )
                .Select(x => x.ContractID)
                .ToListAsync();

            if (allContractIds.Count == 0)
                return new List<Contracts>();

            var allEntities = await context.Contracts.Where(x => allContractIds.Contains(x.ContractID)).ToListAsync();  
            return allEntities;
           // return await Task.FromResult( new List<Contracts>());
            //TODO, join from contract, to document, to document status type where "approve by GS" is in the past 24 hour window
        }
    }
}
