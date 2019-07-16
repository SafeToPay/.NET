using System;
using System.Collections.Generic;

namespace Safe2Pay.Models
{
    public class CarnetItems
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Reference { get; set; }
        public bool IsProcessed { get; set; }
        public string Message { get; set; }
        public PaymentObjectCarnet PaymentObject { get; set; }
    }

    public class PaymentObjectCarnet
    {
        public List<CarnetLotBankSlip> BankSlips { get; set; }
    }

    public class CarnetLotBankSlip
    {
        public int IdTransaction { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
        public string BankSlipNumber { get; set; }
        public string DigitableLine { get; set; }
        public string Barcode { get; set; }
        public DateTime DueDate { get; set; }
    }

}