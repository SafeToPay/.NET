namespace Safe2Pay.Models
{
    public class CheckingAccountList : ListObject<CheckingAccount>
    {
        public decimal TotalAmountDay { get; set; }
        public bool IsReceived { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalChargeback { get; set; }
        public string SelectDate { get; set; }
    }
}