using ContractTracker.Repository.Context;
using ContractTracker.Repository.Implementation;
using ContractTracker.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace ContractTracker.Repository.QueryRepositories
{
    public class ContractTrackingHistoryQueryRepository : IContractTrackingHistoryQueryRepository
    {
        private readonly TrackerDbContext context;
        private const int ApprovedByGeneralServicesTrackingHistoryStepId = 3;
        public ContractTrackingHistoryQueryRepository(IUnitOfWork unitOfWork)
        {
            context = unitOfWork.GetContext();
        }

        public async Task<List<int>> GetAllContractIdsReadyForExporting(DateTime sweepDate)
        {
            var allContractIds = await context.ContractTrackingHistory
                .Where(x => x.ContractTrackingStepsID == ApprovedByGeneralServicesTrackingHistoryStepId &&
                EF.Functions.DateDiffDay(x.TimeStamp, sweepDate) == 1)
                .Select(x => x.ContractID)
                .ToListAsync();

            return allContractIds;
        }
    }
}
