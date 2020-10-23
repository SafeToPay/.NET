using System;
using System.Collections.Generic;

namespace Safe2Pay.Models
{
    public class SingleSale
    {
        public Customer Customer { get; set; }
        public string Reference { get; set; }
        public string CallbackUrl { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal PenaltyAmount { get; set; }
        public decimal InterestAmount { get; set; }
        public List<string> Emails { get; set; }
        public List<string> Messages { get; set; }
        public List<Split> Splits { get; set; }
        public string Instruction { get; set; }
        public SingleSalePayment Payment { get; set; }
        public List<Product> Products { get; set; }
        public List<PaymentMethod> PaymentMethods { get; set; }
        public int InstallmentQuantity { get; set; }
        public int DiscountType { get; set; }
    }
}