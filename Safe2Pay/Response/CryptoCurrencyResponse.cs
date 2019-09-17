namespace Safe2Pay.Response
{
    public class CryptoCurrencyResponse
    {
        public string IdTransaction { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public string QrCode { get; set; }
        public string Symbol { get; set; }
        public decimal AmountBTC { get; set; }
        public string WalletAddress { get; set; }
    }
}