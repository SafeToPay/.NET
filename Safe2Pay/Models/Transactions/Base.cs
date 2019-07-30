using System.Collections.Generic;

namespace Safe2Pay.Models
{
    public class Base
    {
        public int Id { get; set; }
        public int IdTransaction { get; set; }
        public bool IsSandbox { get; set; }
        public string Application { get; set; }
        public string Reference { get; set; }
        public string Vendor { get; set; }
        public string CallbackUrl { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }
        public List<Split> Splits { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
        public dynamic PaymentObject  { get; set; }
        public string Token  { get; set; }
        public string Symbol  { get; set; }

    }
}