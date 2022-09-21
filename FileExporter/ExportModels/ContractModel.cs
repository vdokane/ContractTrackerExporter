using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExporter.ExportModels
{
    public class ContractModel
    {
        public int ContractId { get; set; } = 0;
        public string ContractName { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; } = null;
    }
}
