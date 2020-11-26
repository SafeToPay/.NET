using System;

namespace Safe2Pay.Models.Payment
{
    public class Payment
    {
        public string Code { get; set; }
        public DateTime DueDate { get; set; }
        public AccountDebitTransaction AccountDebitTransaction { get; set; }
    }
}