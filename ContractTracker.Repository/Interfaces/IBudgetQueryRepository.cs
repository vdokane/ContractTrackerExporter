using ContractTracker.Repository.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractTracker.Repository.Interfaces
{
    public interface IBudgetQueryRepository
    {
        Task<List<ContractBudget>> GetBudgetsByContractId(int contractId);
    }
}
