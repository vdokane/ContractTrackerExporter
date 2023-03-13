using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class ExportLog
    {
        [Key]
        public int ExportLogId { get; set; }
        public DateTime InsertDate { get; set; }
        public string ContractNumber { get; set; } = null!;
        public string Step { get; set; } = null!;
        public string? ExportDescription { get; set; }
    }
}
