using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileExporter.ExportModels;

namespace FileExporter.Services
{
    public class ContractExportService
    {
        public List<ContractModel> GetContractsForExporting()
        {
            var seeder = new Seeder();
            var contractModels = seeder.SeedContractModels();
            return contractModels;
        }
    }
}
