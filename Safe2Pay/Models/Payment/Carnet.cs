using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Safe2Pay
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
        public List<CarnetBankslip> BankSlips { get; set; }
    }

    public class CarnetBankslip
    {
        public int IdTransaction { get; set; }
        public int IdMerchant { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public string Instruction { get; set; }
        public List<string> Message { get; set; }
    }
}