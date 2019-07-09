namespace Safe2Pay
{
    public class MerchantSplitTax
    {
        public EnumTaxType TaxTypeName { get; set; }
        public TaxType TaxType { get; set; }
        public decimal Tax { get; set; }
    }
}