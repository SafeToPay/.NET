using System.Collections.Generic;

namespace Safe2Pay
{
    public class Configuration
    {
        public List<MerchantPaymentMethod> MerchantPaymentMethod { get; set; }
        public object MerchantNotify { get; set; }
    }
}