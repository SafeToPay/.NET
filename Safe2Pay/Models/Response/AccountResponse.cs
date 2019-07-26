using System;
using System.Collections.Generic;

namespace Safe2Pay.Models
{
    public class AccountResponse
    {
        //MerchantBankData/Get
        public int Id { get; set; }
        public Bank Bank { get; set; }
        public AccountType AccountType { get; set; }
        public string BankAgency { get; set; }
        public string BankAgencyDigit { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public string Operation { get; set; }

        //MerchantBankData/Update com resposta vazia.
        //Será tratado e as propriedades adicionadas para tratamento da resposta.

        //MerchantPaymentDate/Get
        //public int Id { get; set; }
        public Merchant Merchant { get; set; }
        public PlanFrequence PlanFrequence { get; set; }
        public int PaymentDay { get; set; }

        //MerchantPaymentDate/Update com resposta vazia. 
        //Será tratado e as propriedades adicionadas para tratamento da resposta.

        //CheckingAccount/GetBalance
        public decimal AmountReceived { get; set; }
        public decimal AmountPreview { get; set; }
        public decimal AmountCanceled { get; set; }
        public decimal AmountContestation { get; set; }
        public decimal AmountTaxes { get; set; }
        public decimal AmountAvailableToday { get; set; }

        //CheckingAccount/List
        //public int Id { get; set; }
        //public Merchant Merchant { get; set; }
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

        //CheckingAccount/ListPeriod
        public decimal TotalAmountDay { get; set; }
        public bool IsReceived { get; set; }
        public decimal TotalTax { get; set; }
        public string SelectDate { get; set; }
        public List<CheckingAccount> Objects { get; set; }
        public int TotalItems { get; set; }
    }
}