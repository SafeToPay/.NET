using System;

namespace Safe2Pay.Models
{
    class Notification
    {
        public int IdTransaction { get; set; }
        public int IdMerchant { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
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
        public string Reference { get; set; }
        public string NotificationUrl { get; set; }
    }
}