using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class TrackingSteps
    {
        [Key]
        public int TrackingStepId { get; set; }
        public string StepDescription { get; set; }
        public string StatusCode { get; set; }
        public bool IsActive { get; set; }
    }
}
