﻿using System.Collections.Generic;

namespace Safe2Pay.Models
{
    public class CheckingAccountDeposit
    {
        public string InitialDate { get; set; }
        public string EndDate { get; set; }
        public decimal AmountDeposit { get; set; }
        public decimal AmountTax { get; set; }
        public List<Deposit> Deposits { get; set; }

    }
}
