namespace Safe2Pay.Models
{
    public class Transaction<T> : Base where T : new()
    {
        public T PaymentObject { get; set; }
    }
}