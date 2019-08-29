using System;
using System.Collections.Generic;

namespace Safe2Pay.Models
{
    public class Notification
    {
        public int IdTransaction { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public List<CheckingAccount> CheckingAccounts { get; set; }
        public string Application { get; set; }
        public string Vendor { get; set; }
        public decimal Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? IncluedDate { get; set; }
        public int InstallmentQuantity { get; set; }
        public string SecretKey { get; set; }
        public decimal? TaxValue { get; set; }
        public decimal? NetValue { get; set; }
        public decimal? PaidValue { get; set; }
        public decimal? AdditionValue { get; set; }
        public decimal? DiscountValue { get; set; }
        public string Reference { get; set; }
    }
}