using System;

namespace Safe2Pay
{
    public class CheckingAccount
    {
        public int Id { get; set; }
        public Merchant Merchant { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public int IdTransaction { get; set; }
        public string Description { get; set; }
        public string Reference { get; set; }
        public decimal Amount { get; set; }
        public decimal Tax { get; set; }
        public bool IsTransferred { get; set; }
        public bool IsToday { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int InstallmentNumber { get; set; }
        public int InstallmentQuantity { get; set; }
    }
}