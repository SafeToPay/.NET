using System;
using System.Collections.Generic;

namespace Safe2Pay.Models
{
    public class SubscriptionResponse
    {
        public int Id { get; set; }
        public SubscriptionStatus SubscriptionStatus { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public Plan Plan { get; set; }
        public Customer Customer { get; set; }
        public int ChargeDay { get; set; }
        public int ChargeMonth { get; set; }
        public bool IsSandbox { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CallbackUrl { get; set; }
        public List<PaymentMethod> PaymentMethods { get; set; }
        public int IdSubscriptionCharge { get; set; }
        
        public int SubscriptionLimit { get; set; }
        public int SubscriptionTotal { get; set; }

        public int TotalItems { get; set; }
        public List<Subscription> Objects { get; set; }
    }
}