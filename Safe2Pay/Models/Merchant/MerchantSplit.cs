using System.Collections.Generic;

namespace Safe2Pay
{
    public class MerchantSplit
    {
        public string PaymentMethodCode { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public bool IsSubaccountTaxPayer { get; set; }
        public List<MerchantSplitTax> Taxes { get; set; }
    }
}