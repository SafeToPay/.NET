using System;

namespace Safe2Pay
{
    public class CheckingAccountFilter : Filter<CheckingAccount>
    {
        public DateTime InitialDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsGetAutoNextDate { get; set; }
    }
}