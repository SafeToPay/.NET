namespace Safe2Pay.Models
{
    public class Extract
    {
        public PaymentMethod PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public decimal Tax { get; set; }
        public string Description { get; set; }
        public string Reference { get; set; }
        public int InstallmentCurrent { get; set; }
        public int InstallmentQuantity { get; set; }
        public int IdTransaction { get; set; }
    }
}