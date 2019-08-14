using System;
using System.Collections.Generic;

namespace Safe2Pay.Models
{
    public class CheckoutResponse
    {
        #region CheckoutRequest

        //BankSlip
        public int IdTransaction { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public string BankSlipNumber { get; set; }
        public string DueDate { get; set; }
        public string DigitableLine { get; set; }
        public string Barcode { get; set; }
        public string BankSlipUrl { get; set; }
        public string OperationDate { get; set; }
        public string BankName { get; set; }
        public string CodeBank { get; set; }
        public string Wallet { get; set; }
        public string Agency { get; set; }
        public string Account { get; set; }
        public string CodeAssignor { get; set; }
        public string WalletDescription { get; set; }
        public string AgencyDV { get; set; }
        public string AccountDV { get; set; }
        public string DocType { get; set; }
        public string Accept { get; set; }
        public string GuarantorName { get; set; }
        public string GuarantorIdentity { get; set; }

        //Carnet
        public string CarnetUrl { get; set; }
        public List<Carnet> BankSlips { get; set; }
        public string Identifier { get; set; }

        //CarnetLot
        //public string Identifier { get; set; }
        //public string Message { get; set; }

        //CreditCard
        //public int IdTransaction { get; set; }
        public string Token { get; set; }
        //public string Description { get; set; }
        //public int Status { get; set; }
        //public string Message { get; set; }
        public CreditCard CreditCard { get; set; }
        public string CardNumber { get; set; }
        public string Brand { get; set; }
        public string Installments { get; set; }

        //CryptoCurrency
        //public string IdTransaction { get; set; }
        //public string Status { get; set; }
        //public string Message { get; set; }
        //public string Description { get; set; }
        public string QrCode { get; set; }
        public string Symbol { get; set; }
        public decimal AmountBTC { get; set; }
        public decimal AmountLTC { get; set; }
        public decimal AmountBCH { get; set; }
        public string WalletAddress { get; set; }

        //DebitCard
        //public int IdTransaction { get; set; }
        //public string Token { get; set; }
        //public string Description { get; set; }
        //public int Status { get; set; }
        //public string Message { get; set; }
        public DebitCard DebitCard { get; set; }
        public string AuthenticationUrl { get; set; }

        //DebitAccount
        //public string IdTransaction { get; set; }
        //public int Status { get; set; }
        //public string Message { get; set; }
        //public string Description { get; set; }

        //Transfer
        //public string Message { get; set; }
        //public string Description { get; set; }
        //public string BankSlipNumber { get; set; }
        //public string DueDate { get; set; }
        //public string DigitableLine { get; set; }
        //public string Barcode { get; set; }
        //public string BankSlipUrl { get; set; }
        //public int Id { get; set; }
        public int IdTransfer { get; set; }
        public int IdMerchant { get; set; }
        public BankData BankData { get; set; }
        public string ReceiverName { get; set; }
        public string Identity { get; set; }
        //public decimal Amount { get; set; }
        public string Identification { get; set; }
        //public string CallbackUrl { get; set; }
        public bool IsTransferred { get; set; }
        public bool IsReleaseTransfer { get; set; }
        public bool IsNotified { get; set; }
        public bool IsReturned { get; set; }
        public string HashScheduling { get; set; }
        public string HashConfirmation { get; set; }
        public DateTime CompensationDate { get; set; }
        //public DateTime CreatedDate { get; set; }
        public DateTime ChangedDate { get; set; }
        public string Validation { get; set; }
        public List<BankingTransferOccurrenceReason> BankingTransferOccurrenceReason { get; set; }
        public int IdMerchantRequester { get; set; }
        public int IdTransferRegisterLot { get; set; }

        #endregion

        #region TransactionRequest

        //Detail / List / ListByReference
        public int Id { get; set; }
        public dynamic PaymentObject { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
        public Gateway Gateway { get; set; }
        public Merchant Merchant { get; set; }
        public TaxType TaxType { get; set; }
        public Customer Customer { get; set; }
        public decimal Amount { get; set; }
        public decimal TaxValue { get; set; }
        public object Currency { get; set; }
        public string Application { get; set; }
        public string Reference { get; set; }
        public decimal NegotiationTax { get; set; }
        public decimal AcquirerTax { get; set; }
        public decimal DiscountAmount { get; set; }
        public string Vendor { get; set; }
        public string CallbackUrl { get; set; }
        public bool IsExcluded { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Split> Splits { get; set; }
        public decimal NetValue { get; set; }
        public bool IsSandbox { get; set; }
        public List<Product> Products { get; set; }
        public int IdSubscription { get; set; }
        public object PaymentInfo { get; set; }
        public object CardBrand { get; set; }
        public int ApiVersion { get; set; }
        public List<CheckoutResponse> Objects { get; set; }
        public int TotalItems { get; set; }
        public bool isCancelled { get; set; }
        //public string Message { get; set; }
        //public List<BankSlip> BankSlips { get; set; }
        public bool IsProcessed { get; set; }
        //public string Message { get; set; }
        public string IdentifierLot { get; set; }
        //public bool IsExcluded { get; set; }
        //public string Message { get; set; }
        #endregion
    }
}
