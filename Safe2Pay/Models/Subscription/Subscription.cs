using System;
using System.Collections.Generic;

namespace Safe2Pay.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public int Plan { get; set; }
        public DateTime ChargeDate { get; set; }
        public bool IsSandbox { get; set; }
        public Customer Customer { get; set; }
        public dynamic SubscriptionObject { get; set; }
        public string CallbackUrl { get; set; }
    }
}