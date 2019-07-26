using System;

namespace Safe2Pay.Models
{
    public class Payment
    {
        public string Code { get; set; }
        public DateTime DueDate { get; set; }
        public AccountDebitTransaction AccountDebitTransaction { get; set; }
    }
}