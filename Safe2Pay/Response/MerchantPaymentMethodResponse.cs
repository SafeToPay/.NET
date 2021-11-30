namespace Safe2Pay.Response
{
    public class MerchantPaymentMethodResponse
    {
        public PaymentMethodResponse PaymentMethod { get; set; }
        public bool IsEnabled { get; set; }
        public decimal InstallmentLimit { get; set; }
        public decimal MinorInstallmentAmount { get; set; }
        public decimal IsInstallmentEnable { get; set; }
    }
}