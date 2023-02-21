using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class MethodOfPayments
    {
        [Key]
        public int MethodOfPaymentsID { get; set; }
        public string PaymentDescription { get; set; } = string.Empty;
    }
}
