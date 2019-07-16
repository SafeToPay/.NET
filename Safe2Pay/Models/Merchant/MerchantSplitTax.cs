namespace Safe2Pay.Models
{
    public class MerchantSplitTax
    {
        public EnumTaxType TaxTypeName { get; set; }
        public TaxType TaxType { get; set; }
        public decimal Tax { get; set; }
    }
}