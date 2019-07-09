namespace Safe2Pay
{
    public class CreditCardResponse
    {
        public string CardNumber { get; set; }
        public int Brand { get; set; }
        public int Installments { get; set; }
    }
}