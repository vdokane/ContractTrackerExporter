using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class UserRoles
    {
        [Key]
        public int UserRoleId { get; set; }
        public string UserRoleDescription { get; set; }
    }
}
