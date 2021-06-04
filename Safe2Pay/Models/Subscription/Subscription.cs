using System;
using System.Collections.Generic;

namespace Safe2Pay.Models.Subscription
{
    public class Subscription
    {
        public int Plan { get; set; }
        public string PaymentMethod { get; set; }
        public List<string> Emails { get; set; }
        public Customer Customer { get; set; }
        public DateTime ChargeDate { get; set; }
        public DateTime FirstChargeDate { get; set; }
        public bool IsSandbox { get; set; }
        public CreditCard CreditCard { get; set; }
        public string Token { get; set; }
        public bool IsSendSMS { get; set; }
        public bool IsSendEmail { get; set; }
        public string ChargeUrl { get; set; }
        public bool HasError { get; set; }
    }
}