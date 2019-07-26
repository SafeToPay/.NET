namespace Safe2Pay.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public Merchant Merchant { get; set; }
        public string Name { get; set; }
        public string Identity { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
    }
}