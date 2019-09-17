namespace Safe2Pay.Response
{
    public class DebitCardResponse
    {
        public int IdTransaction { get; set; }
        public string Token { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public string AuthenticationUrl { get; set; }
        public bool isCancelled { get; set; }
        public DebitCardDetails DebitCard { get; set; }
    }

    public class DebitCardDetails
    {
        public string CardNumber { get; set; }
        public int Brand { get; set; }
    }
}