using System;

namespace Safe2Pay.Models
{
    public class SingleSalePayment
    {
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}