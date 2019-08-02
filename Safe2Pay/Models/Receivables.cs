using System;
using System.Collections.Generic;
using System.Text;

namespace Safe2Pay.Models
{
    public class Receivables
    {
        public decimal AmountReceivables { get; set; }
        public decimal AmountNetReceivables { get; set; }
        public decimal Tax { get; set; }
        public bool IsFunds { get; set; }
    }
}
