namespace Safe2Pay.Response
{
    public class PaymentObjectResponse
    {
        public string BankSlipNumber { get; set; }
        public string DueDate { get; set; }
        public string DigitableLine { get; set; }
        public string Barcode { get; set; }
        public string BankSlipUrl { get; set; }

        public string Token { get; set; }
        public string CardNumber { get; set; }
        public string Brand { get; set; }
        public int Installments { get; set; }

        public string QrCode { get; set; }
        public decimal AmountBTC { get; set; }
        public string WalletAddress { get; set; }
    }
}