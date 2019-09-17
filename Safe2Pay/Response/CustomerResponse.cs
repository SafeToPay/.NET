namespace Safe2Pay.Response
{
    public class CustomerResponse
    {
        public string Name { get; set; }
        public string Identity { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public AddressResponse Address { get; set; }
    }
}