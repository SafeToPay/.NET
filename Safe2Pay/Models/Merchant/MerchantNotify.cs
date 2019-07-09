namespace Safe2Pay
{
    public class MerchantNotify
    {
        public int Id { get; set; }
        public Merchant Merchant { get; set; }
        public bool IsPaymentReceived { get; set; }
        public bool IsBankSlipCreated { get; set; }
        public bool IsBankSlipDue { get; set; }
        public bool IsPaymentRefused { get; set; }
    }
}