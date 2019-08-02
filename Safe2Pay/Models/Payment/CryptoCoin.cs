namespace Safe2Pay.Models
{
    public class CryptoCoin
    {
        public string Symbol { get; set; }
        public decimal Amount { get; set; }
        public string Address { get; set; }
        public string QrCode { get; set; }
    }
}