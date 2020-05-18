namespace Safe2Pay.Response
{
    public class TransactionResponse
    {
        public int IdTransaction { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string Application { get; set; }
        public string Vendor { get; set; }
        public string Reference { get; set; }
        public string PaymentDate { get; set; }
        public string CreatedDate { get; set; }
        public decimal Amount { get; set; }
        public decimal NetValue { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxValue { get; set; }
        public string PaymentMethod { get; set; }
        public CustomerResponse Customer { get; set; }
        public decimal AmountPayment { get; set; }
        public bool Success { get; set; }
        public PaymentObjectResponse PaymentObject { get; set; }
    }
}