using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractTracker.Repository.EntityModels
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }

        [ForeignKey("UserRoleId")]
        public int UserRoleID { get; set; }
        //public UserRoles? UserRoles { get; set; }
        public string UserLogInName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string? UserEmail { get; set; } = string.Empty;
        public string? PositionTitle { get; set; } = string.Empty;
        public DateTime? Start { get; set; }
        public DateTime? Stop { get; set; }
        public string? OfficeTelephone { get; set; }
        public int? ContactLKID { get; set; }
        public DateTime? TimeStamp { get; set; }


    }
}
