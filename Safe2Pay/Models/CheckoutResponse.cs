using System.Collections.Generic;

namespace Safe2Pay
{
    public class CheckoutResponse
    {
        public int IdTransaction { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }

        //Boleto bancário
        public string BankSlipNumber { get; set; }
        public string DueDate { get; set; }
        public string DigitableLine { get; set; }
        public string Barcode { get; set; }
        public string BankSlipUrl { get; set; }

        //Carnê
        public string CarnetUrl { get; set; }
        public List<BankSlip> BankSlips { get; set; }
        public string Identifier { get; set; }

        //Cartão de crédito
        public string Token { get; set; }
        public CreditCardResponse CreditCard { get; set; }
        public bool isCancelled { get; set; }

        //BitCoin
        public string QrCode { get; set; }
        public decimal AmountBTC { get; set; }
        public string WalletAddress { get; set; }

        //Cartão de débito
        //public string Token { get; set; }
        public DebitCardResponse DebitCard { get; set; }
        public string AuthenticationUrl { get; set; }
    }
}