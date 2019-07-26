using System.Collections.Generic;

namespace Safe2Pay.Models
{
    public class Carnet
    {
        public int Id { get; set; }
        public int IdCarnetLot { get; set; }
        public string Identifier { get; set; }
        public string Reference { get; set; }
        public bool IsProcessed { get; set; }
        public bool IsAsync { get; set; }
        public string Message { get; set; }
        public decimal PenaltyAmount { get; set; }
        public decimal InterestAmount { get; set; }
        public bool PayableAfterDue { get; set; }
        public bool IsEnablePartialPayment { get; set; }
        public List<BankSlip> BankSlips { get; set; }
    }
}