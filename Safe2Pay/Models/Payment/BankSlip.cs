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
        public string OperationDate { get; set; }
        public string BankName { get; set; }
        public string CodeBank { get; set; }
        public string Wallet { get; set; }
        public string Agency { get; set; }
        public string Account { get; set; }
        public string CodeAssignor { get; set; }
        public int? DiscountType { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime? DiscountDue { get; set; }
        public decimal? AdditionPayment { get; set; }
        public decimal? DiscountPayment { get; set; }
    }
}