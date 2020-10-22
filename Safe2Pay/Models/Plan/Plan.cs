using System;

namespace Safe2Pay.Models
{
    public class Plan
    {
        public int Id { get; set; }
        public PlanFrequence PlanFrequence { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal SubscriptionTax { get; set; }
        public int SubscriptionLimit { get; set; }
        public int ChargeDay { get; set; }
        public int DaysTrial { get; set; }
        public int DaysChurn { get; set; }
        public int DaysChurnAlert { get; set; }
        public int DaysDelayAlert { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsImmediateCharge { get; set; }
        public string CallbackUrl { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int DaysDue { get; set; }
        public int DaysBeforeCancel { get; set; }
        public string Instruction { get; set; }
        public decimal PenaltyAmount { get; set; }
        public decimal InterestAmount { get; set; }
        public string Message { get; set; }
        public bool IsChargeOverdue { get; set; }
    }
}