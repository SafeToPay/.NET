using System;
using System.Collections.Generic;

namespace Safe2Pay.Models
{
    public class BankSlip
    {
        public DateTime DueDate { get; set; }
        public string Instruction { get; set; }
        public List<string> Message { get; set; }
        public decimal PenaltyRate { get; set; }
        public decimal InterestRate { get; set; }
        public bool IsEnablePartialPayment { get; set; }
        public bool CancelAfterDue { get; set; }
        public int DaysBeforeCancel { get; set; }
        public int DiscountType { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime DiscountDue { get; set; }
        public decimal Amount { get; set; }
    }
}