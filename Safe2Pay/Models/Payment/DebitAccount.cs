using System;

namespace Safe2Pay.Models
{
    public class DebitAccount
    {
        public int Id { get; set; }
        public BankData BankData { get; set; }
        public bool IsRecurring { get; set; }
        public int RecurringDayMonth { get; set; }
        public int DebitId { get; set; }
        public string DebitCode { get; set; }
        public DateTime? DueDate { get; set; }
    }
}