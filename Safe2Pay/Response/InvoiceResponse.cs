using System.Collections.Generic;
using Safe2Pay.Models;

namespace Safe2Pay.Response
{
    public class InvoiceResponse
    {
        public string SingleSaleHash { get; set; }
        public string DueDate { get; set; }
        public string ExpirationDate { get; set; }
        public decimal Amount { get; set; }
        public string CreatedDate { get; set; }
        public string CallbackUrl { get; set; }
        public string Status { get; set; }
        public bool IsApplyPenalty { get; set; }
        public decimal PenaltyAmount { get; set; }
        public bool IsApplyInterest { get; set; }
        public decimal InterestAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public string BankSlipUrl { get; set; }
        public string SingleSaleUrl { get; set; }
        public List<Product> Products { get; set; }
        public List<string> Emails { get; set; }
        public CustomerResponse Customer { get; set; }
    }
}