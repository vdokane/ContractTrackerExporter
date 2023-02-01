using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class Announcements
    {
        [Key]
        public int AnnouncementId { get; set; }
        public string? AnnouncementMessage { get; set; }
        public int UserId { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
