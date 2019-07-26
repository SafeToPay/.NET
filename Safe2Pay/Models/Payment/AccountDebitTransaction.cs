using System;

namespace Safe2Pay.Models
{
    public class AccountDebitTransaction
    {
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public string Status { get; set; }
        public string TransactionStatus { get; set; }
        public string TransactionStatusMessage { get; set; }
        public DateTime? TransactionStatusDate { get; set; }
        public DateTime? TransactionDebitDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}