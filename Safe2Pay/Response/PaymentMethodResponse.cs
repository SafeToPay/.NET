using System.Collections.Generic;

namespace Safe2Pay.Response
{
    public class PaymentMethodResponse
    {
        public string PaymentMethod { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsPayTax { get; set; }
        public List<TaxResponse> Taxes { get; set; }
    }
}