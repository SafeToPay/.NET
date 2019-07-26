namespace Safe2Pay.Models
{
    public class Gateway
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int ReleaseDays { get; set; }
    }
}