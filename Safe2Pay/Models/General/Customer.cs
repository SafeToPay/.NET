namespace Safe2Pay
{
    public class Customer
    {
        public string Name { get; set; }
        public string Identity { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        
        public Address Address { get; set; }
    }
}