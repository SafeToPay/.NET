namespace Safe2Pay
{
    public class CreditCard
    {
        public string Holder { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public string Token { get; set; }
        public int InstallmentQuantity { get; set; }
        public bool IsRecurrence { get; set; }
    }
}