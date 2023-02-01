using ContractTracker.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExporter.Services
{
    public class delete_ChangeExportService
    {
        private readonly IContractChangeQueryRepository changeQueryRepository;
        public delete_ChangeExportService(IContractChangeQueryRepository changeQueryRepository)
        {
            this.changeQueryRepository = changeQueryRepository; 
        }
    }
}
