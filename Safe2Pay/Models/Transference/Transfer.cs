using System;
using System.Collections.Generic;

namespace Safe2Pay.Models
{
    public class Transfer
    {
        public int Id { get; set; }
        public int Sequence { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Filename { get; set; }
        public string File { get; set; }
        public List<TransferRegister> TransferRegister { get; set; }
    }
}