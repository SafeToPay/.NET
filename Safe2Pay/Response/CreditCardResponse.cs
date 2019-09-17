namespace Safe2Pay.Response
{
    public class CreditCardResponse
    {
        public int IdTransaction { get; set; }
        public string Token { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public bool isCancelled { get; set; }
        public CreditCardDetails CreditCard { get; set; }
    }
}