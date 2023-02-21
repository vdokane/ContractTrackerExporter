using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExporter.ExportModels
{
    public class ContractChangeExportModel
    {
        public int ContractChangeID { get; set; }
        public int ContractID { get; set; }
        public string ContractChangeType { get; set; } = string.Empty;
        public decimal AmendmentAmount { get; set; }
        public string AmendmentReference { get; set; } = string.Empty;
        public DateTime AmendmentEffectiveDate { get; set; }
        public DateTime ChangeDateExecuted { get; set; }
        public DateTime? NewEndingDate { get; set; }
        public string ChangeDescription { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public DateTime? ExportDate { get; set; }
    }
}
