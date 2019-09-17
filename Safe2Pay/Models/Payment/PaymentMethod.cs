namespace Safe2Pay.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public string CodePaymentMethod { get; set; }
    }
}