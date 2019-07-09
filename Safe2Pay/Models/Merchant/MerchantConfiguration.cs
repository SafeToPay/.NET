using System.Collections.Generic;

namespace Safe2Pay
{
    public class MerchantConfiguration
    {
        public List<MerchantPaymentMethod> MerchantPaymentMethod { get; set; }
        public MerchantNotify MerchantNotify { get; set; }
    }
}