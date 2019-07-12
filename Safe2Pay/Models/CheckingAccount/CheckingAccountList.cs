namespace Safe2Pay
{
    public class CheckingAccountList : ListObject<CheckingAccount>
    {
        public decimal TotalAmountDay { get; set; }
        public bool IsReceived { get; set; }
        public decimal TotalTax { get; set; }
        public string SelectDate { get; set; }
    }
}