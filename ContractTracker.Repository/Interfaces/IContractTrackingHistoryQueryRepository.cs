using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractTracker.Repository.Interfaces
{
    public interface IContractTrackingHistoryQueryRepository
    {
        Task<List<int>> GetAllContractIdsReadyForExporting(DateTime sweepDate);
    }
}
