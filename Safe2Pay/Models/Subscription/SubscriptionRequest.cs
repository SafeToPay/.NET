using System;
using System.Collections.Generic;

namespace Safe2Pay.Models.Subscription
{
    public class SubscriptionRequest
    {
        public int Plan { get; set; }
        public int Subscription { get; set; }
        public string PaymentMethod { get; set; }
        public List<string> Emails { get; set; }
        public Customer Customer { get; set; }
        public DateTime ChargeDate { get; set; }
        public bool IsSandbox { get; set; }
        public CreditCard CreditCard { get; set; }
        public string Token { get; set; }
    }
}