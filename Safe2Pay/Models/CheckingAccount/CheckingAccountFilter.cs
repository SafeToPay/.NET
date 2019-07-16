using System;

namespace Safe2Pay.Models
{
    public class CheckingAccountFilter : Filter<CheckingAccount>
    {
        public DateTime InitialDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsGetAutoNextDate { get; set; }
    }
}