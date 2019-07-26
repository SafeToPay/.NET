namespace Safe2Pay.Models
{
    public class CreditCard
    {
        public string Holder { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public string Token { get; set; }
        public string Tid { get; set; }
        public string ProofOfSale { get; set; }
        public string AuthorizationCode { get; set; }
        public string ReturnCode { get; set; }
        public string MaskedCardNumber { get; set; }
        public bool IsCaptured { get; set; }
        public int Brand { get; set; }
        public int InstallmentQuantity { get; set; }
        public bool IsRecurrence { get; set; }
        public string TokenCard { get; set; }
        public bool isCancelled { get; set; }
    }
}