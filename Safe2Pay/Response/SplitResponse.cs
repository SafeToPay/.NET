using System;
using System.Collections.Generic;
using System.Text;

namespace Safe2Pay.Response
{
    public class SplitResponse
    {
        public int IdTransactionSplitter { get; set; }
        public string Name { get; set; }
        public string Identity { get; set; }
        public int? IdReceiver { get; set; }
        public bool IsPayTax { get; set; }
        public decimal Amount { get; set; }

    }
}
