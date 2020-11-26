using System;
using System.Collections.Generic;
using System.Text;

namespace Safe2Pay.Response
{
    public class AdvancePaymentItemsResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string InstallmentQuantity { get; set; }
    }
}
