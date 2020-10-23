using System.Collections.Generic;

namespace Safe2Pay.Models
{
    public class TransactionBase
    {
        public bool IsSandbox { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
        public string CallbackUrl { get; set; }
        public string Application { get; set; }
        public string Reference { get; set; }
        public string Vendor { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }
        public List<Split> Splits { get; set; }
        public bool ShouldUseAntifraud { get; set; }
        public string VisitorID { get; set; }
        public string IpAddress { get; set; }
    }
}