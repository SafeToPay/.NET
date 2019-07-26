using System;
using System.Collections.Generic;

namespace Safe2Pay.Models
{
    public class BankSlip
    {
        public int Id { get; set; }
        public int IdCarnet { get; set; }
        public int IdTransaction { get; set; }
        public long SeedNumber { get; set; }
        public string BankSlipNumber { get; set; }
        public string DigitableLine { get; set; }
        public string Barcode { get; set; }
        public string File { get; set; }
        public decimal AmountPayment { get; set; }
        public DateTime DueDate { get; set; }
        public string Instruction { get; set; }
        public List<string> Message { get; set; }
        public decimal PenaltyRate { get; set; }
        public decimal InterestRate { get; set; }
        public string BankSplipUrl { get; set; }
        public bool CancelAfterDue { get; set; }
        public bool IsEnablePartialPayment { get; set; }
        public int DaysBeforeCancel { get; set; }
        public int IdMerchant { get; set; }
        public string Status { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public bool isCancelled { get; set; }
    }
}