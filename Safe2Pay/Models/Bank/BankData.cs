namespace Safe2Pay.Models
{
    public class BankData
    {
        public Bank Bank { get; set; }
        public string BankAgency { get; set; }
        public string BankAgencyDigit { get; set; }
        public string BankAccount { get; set; }
        public string BankAccountDigit { get; set; }
        public string Operation { get; set; }
    }
}