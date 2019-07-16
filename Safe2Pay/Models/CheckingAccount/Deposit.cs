using System;
using System.Collections.Generic;
using System.Text;

namespace Safe2Pay.Models
{
    public class Deposit
    {
        public string DepositDate { get; set; }
        public decimal Amount { get; set; }
        public bool IsTransferred { get; set; }
        public decimal Tax { get; set; }
        public List<Extract> Extracts { get; set; }
        public int TotalItems { get; set; }
    }
}
