using System;
using System.Collections.Generic;

namespace Safe2Pay
{
    public class AccountResponse
    {
        public int Id { get; set; }
        public Bank Bank { get; set; }
        public string BankAgency { get; set; }
        public string BankAgencyDigit { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public string Operation { get; set; }

        public double AmountReceived { get; set; }
        public double AmountPreview { get; set; }
        public double AmountCanceled { get; set; }
        public double AmountContestation { get; set; }
        public double AmountTaxes { get; set; }
        public double AmountAvailableToday { get; set; }

        public string InitialDate { get; set; }
        public string EndDate { get; set; }
        public double AmountDeposit { get; set; }
        public double AmountTax { get; set; }
        public List<Deposit> Deposits { get; set; }

        public object Merchant { get; set; }
        public object PaymentMethod { get; set; }
        public int IdTransaction { get; set; }
        public object Description { get; set; }
        public object Reference { get; set; }
        public double Amount { get; set; }
        public double Tax { get; set; }
        public bool IsTransferred { get; set; }
        public bool IsToday { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int InstallmentNumber { get; set; }
        public int InstallmentQuantity { get; set; }

        public double TotalAmountDay { get; set; }
        public bool IsReceived { get; set; }
        public double TotalTax { get; set; }
        public string SelectDate { get; set; }
        public List<object> Objects { get; set; }
        public int TotalItems { get; set; }

        public string DepositDate { get; set; }
        public List<Extract> Extracts { get; set; }


    }
}