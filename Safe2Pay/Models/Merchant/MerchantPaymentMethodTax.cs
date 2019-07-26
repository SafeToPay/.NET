namespace Safe2Pay.Models
{
    public class MerchantPaymentMethodTax
    {
        public int Id { get; set; }
        public int IdMerchantPaymentMethod { get; set; }
        public int InitialInstallment { get; set; }
        public int EndInstallment { get; set; }
        public decimal Amount { get; set; }
        public TaxType TaxType { get; set; }
    }
}