using System.Collections.Generic;

namespace Safe2Pay.Response
{
    public class AdvancePaymentResponse
    {
        public string AmountReceivables { get; set; }
        public string AmountNetReceivables { get; set; }
        public string Message { get; set; }
        public string Tax { get; set; }
        public List<AdvancePaymentItemsResponse> Items { get; set; }
    }
}
