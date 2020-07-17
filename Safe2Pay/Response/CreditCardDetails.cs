namespace Safe2Pay.Response
{
    public class CreditCardDetails
    {
        public string CardNumber { get; set; }
        public int? Brand { get; set; }
        public int? Installments { get; set; }
    }
}