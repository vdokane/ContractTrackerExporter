using System;
using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class Reports
    {
        [Key]
        public int ReportId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Description2 { get; set; } = string.Empty;
        public string Description3 { get; set; } = string.Empty;
        public string DrillThruValue { get; set; } = string.Empty;
        public DateTime? Start { get; set; }
        public DateTime? Stop { get; set; }
        public string ProcName { get; set; } = string.Empty;
        public string ReportType { get; set; } = string.Empty;
        public bool ReadOnlyAccess { get; set; }
        public string BreakTabOn { get; set; } = string.Empty;
        public string CategoryAxis { get; set; } = string.Empty;
        public string ValueAxis { get; set; } = string.Empty;
        public bool ShowDateRange { get; set; }
        public int WaitSecs { get; set; }
        public string OptionalFilter { get; set; } = string.Empty;
    }
}
