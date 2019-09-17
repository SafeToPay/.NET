using System.Collections.Generic;
using Safe2Pay.Models;

namespace Safe2Pay.Response
{
    public class PaymentMethodResponse
    {
        public string PaymentMethod { get; set; }
        public bool IsPayTax { get; set; }
        public List<TaxResponse> Taxes { get; set; }
    }
}