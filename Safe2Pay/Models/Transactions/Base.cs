using System;
using System.Collections.Generic;

namespace Safe2Pay.Models
{
    public class Base
    {
        public int Id { get; set; }
        public int IdTransaction { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
        public Gateway Gateway { get; set; }
        public Merchant Merchant { get; set; }
        public TaxType TaxType { get; set; }
        public Customer Customer { get; set; }
        public decimal Amount { get; set; }
        public decimal TaxValue { get; set; }
        public string Currency { get; set; }
        public string Application { get; set; }
        public string Reference { get; set; }
        public decimal NegotiationTax { get; set; }
        public decimal AcquirerTax { get; set; }
        public decimal DiscountAmount { get; set; }
        public string Vendor { get; set; }
        public string CallbackUrl { get; set; }
        public bool IsExcluded { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Split> Splits { get; set; }
        public decimal NetValue { get; set; }
        public bool IsSandbox { get; set; }
        public bool IsSplitter { get; set; }
        public List<Product> Products { get; set; }
        public int IdSubscription { get; set; }
        public string PaymentInfo { get; set; }
        public string CardBrand { get; set; }
        public int ApiVersion { get; set; }
    }
}