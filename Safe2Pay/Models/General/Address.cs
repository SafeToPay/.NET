namespace Safe2Pay
{
    public class Address
    {
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string CityName { get; set; }
        public string StateInitials { get; set; }
        public string CountryName { get; set; }

        public City City { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public int IdState { get; set; }
        public string CodeIBGE { get; set; }
        public string Name { get; set; }
    }

    public class State
    {
        public int Id { get; set; }
        public int IdCountry { get; set; }
        public string Initials { get; set; }
        public object Name { get; set; }
    }

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}