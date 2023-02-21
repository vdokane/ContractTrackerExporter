using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractTracker.Repository.EntityModels
{
    public class UserUnits
    {
        [Key]
        public int UserUnitId { get; set; }
        public int UserId { get; set; }
        public int UnitId { get; set; }
        public int EndDate { get; set; }


        [ForeignKey("UnitId")]
        public Units Units { get; set; }

        [ForeignKey("UserId")]
        public Users Users { get; set; }
    }
}
