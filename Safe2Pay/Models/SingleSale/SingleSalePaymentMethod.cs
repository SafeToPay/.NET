namespace Safe2Pay.Models
{
    public class SingleSalePaymentMethod
    {
        public int Id { get; set; }
        public int IdSingleSale { get; set; }
        public string CodePaymentMethod { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}