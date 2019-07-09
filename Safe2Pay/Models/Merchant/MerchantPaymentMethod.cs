using System.Collections.Generic;

namespace Safe2Pay
{
    public class MerchantPaymentMethod
    {
        public int Id { get; set; }
        public Merchant Merchant { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public bool IsEnabled { get; set; }
        public int InstallmentLimit { get; set; }
        public decimal MinorInstallmentAmount { get; set; }
    }
}