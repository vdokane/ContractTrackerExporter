using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractTracker.Repository.EntityModels
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [ForeignKey("UserRoleId")]
        public int UserRoleId { get; set; }
        public UserRoles UserRoles { get; set; }
        public string UserLogInName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string PositionTitle { get; set; } = string.Empty;
        public DateTime? AddDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }

    }
}
