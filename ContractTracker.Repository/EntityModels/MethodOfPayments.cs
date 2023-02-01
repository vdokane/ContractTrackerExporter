using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class MethodOfPayments
    {
        [Key]
        public int MethodOfPaymentId { get; set; }
        public string PaymentDescription { get; set; } = string.Empty;
    }
}
