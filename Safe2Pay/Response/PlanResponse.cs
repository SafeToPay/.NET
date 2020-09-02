using System;
using Safe2Pay.Models;

namespace Safe2Pay.Response
{
    public class PlanResponse
    {
        public int Id { get; set; }
        public PlanFrequence PlanFrequence { get; set; }
        public object Merchant { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public double SubscriptionTax { get; set; }
        public int SubscriptionLimit { get; set; }
        public int ChargeDay { get; set; }
        public int DaysTrial { get; set; }
        public int DaysChurn { get; set; }
        public int DaysChurnAlert { get; set; }
        public int DaysDelayAlert { get; set; }
        public bool IsProRata { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsImmediateCharge { get; set; }
        public string CallbackUrl { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int DaysDue { get; set; }
        public int DaysBeforeCancel { get; set; }
        public object Instruction { get; set; }
        public double PenaltyAmount { get; set; }
        public double InterestAmount { get; set; }
        public object Message { get; set; }
        public int SubscriptionTotal { get; set; }
        public object Status { get; set; }
    }
}