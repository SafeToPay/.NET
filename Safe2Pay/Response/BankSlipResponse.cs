namespace Safe2Pay.Response
{
    public class BankSlipResponse
    {
        public int IdTransaction { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public string BankSlipNumber { get; set; }
        public string DueDate { get; set; }
        public string DigitableLine { get; set; }
        public string Barcode { get; set; }
        public string BankSlipUrl { get; set; }
        public string OperationDate { get; set; }
        public string BankName { get; set; }
        public string CodeBank { get; set; }
        public string Wallet { get; set; }
        public string WalletDescription { get; set; }
        public string Agency { get; set; }
        public string Account { get; set; }
        public string CodeAssignor { get; set; }
        public string AgencyDV { get; set; }
        public string AccountDV { get; set; }
        public string DocType { get; set; }
        public string Accept { get; set; }
        public string Currency { get; set; }
        public string GuarantorName { get; set; }
        public string GuarantorIdentity { get; set; }

        //Carnê
        public bool isCancelled { get; set; }
    }
}