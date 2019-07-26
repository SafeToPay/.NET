using System;

namespace Safe2Pay.Models
{
    public class Plan
    {
        public int Id { get; set; }
        public PlanFrequence PlanFrequence { get; set; }
        public Merchant Merchant { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int? SubscriptionLimit { get; set; }
        public int? DaysTrial { get; set; }
        public int? DaysToInactive { get; set; }
        public int? ChargeDay { get; set; }
        public decimal? SubscriptionTax { get; set; }
        public bool? IsProRata { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsImmediateCharge { get; set; }
        public string CallbackUrl { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ChangedDate { get; set; }
        public int SubscriptionTotal { get; set; }
        public object Status { get; set; }
    }
}