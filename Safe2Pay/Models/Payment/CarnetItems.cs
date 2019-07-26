namespace Safe2Pay.Models
{
    public class CarnetItems
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Reference { get; set; }
        public bool IsProcessed { get; set; }
        public string Message { get; set; }
        public PaymentObjectCarnet PaymentObject { get; set; }
    }
}