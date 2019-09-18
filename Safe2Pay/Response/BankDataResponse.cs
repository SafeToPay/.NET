namespace Safe2Pay.Response
{
    public class BankDataResponse
    {
        public string Bank { get; set; }
        public string Agency { get; set; }
        public string AgencyDigit { get; set; }
        public string Account { get; set; }
        public string AccountDigit { get; set; }
        public string Operation { get; set; }
    }
}