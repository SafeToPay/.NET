namespace Safe2Pay.Models
{
    public class Address
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string ZipCode { get; set; }
        public string Complement { get; set; }
        public string CityName { get; set; }
        public string StateInitials { get; set; }
        public string CountryName { get; set; }
    }
}