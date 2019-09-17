namespace Safe2Pay.Models
{
    public class BankTransfer
    {
        public int Provider { get; set; }
        public string Token { get; set; }
        public string AuthenticationUrl { get; set; }
    }
}