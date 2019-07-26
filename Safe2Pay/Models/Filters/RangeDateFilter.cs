using System;

namespace Safe2Pay.Models
{
    public class RangeDateFilter<T> : Filter<T> where T : new()
    {
        public DateTime InitialDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}