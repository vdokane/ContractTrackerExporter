using System;
using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class ErrorLogs
    {
        [Key]
        public int ErrorLogId { get; set; }
        public string ErrorDescription { get; set; }
        public int? UserId { get; set; }
        public DateTime InsertDate { get; set; }
        public string TableAbbrv { get; set; }
        public string TablePK { get; set; }
        public string ProcedureName { get; set; }
        public string ProcedureStage { get; set; }
        public int? Severity { get; set; }
    }
}
