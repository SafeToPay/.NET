namespace Safe2Pay
{
    public class CheckingAccountBalance
    {
        public decimal AmountReceived { get; set; }
        public decimal AmountPreview { get; set; }
        public decimal AmountCanceled { get; set; }
        public decimal AmountContestation { get; set; }
        public decimal AmountTaxes { get; set; }
        public decimal AmountAvailableToday { get; set; }
    }
}