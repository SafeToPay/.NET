namespace Safe2Pay.Models
{
    public class MerchantNotify
    {
        public Merchant Merchant { get; set; }
        public bool IsPaymentReceived { get; set; }
        public bool IsBankSlipCreated { get; set; }
        public bool IsBankSlipDue { get; set; }
        public bool IsPaymentRefused { get; set; }
    }
}