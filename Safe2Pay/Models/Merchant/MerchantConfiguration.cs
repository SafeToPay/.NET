using System.Collections.Generic;

namespace Safe2Pay.Models
{
    public class MerchantConfiguration
    {
        public List<MerchantPaymentMethod> MerchantPaymentMethod { get; set; }
        public MerchantNotify MerchantNotify { get; set; }
    }
}