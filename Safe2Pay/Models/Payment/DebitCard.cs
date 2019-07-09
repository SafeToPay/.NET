namespace Safe2Pay
{
    public class DebitCard
    {
        public string Holder { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public string Token { get; set; }
        public bool Authenticate { get; set; }
    }
}