using System;
using System.Collections.Generic;

namespace Safe2Pay.Models
{
    public class TransferRegisterLot
    {
        public int Id { get; set; }

        public int IdMerchantRequester { get; set; }
        public int IdTransaction { get; set; }
        public decimal AmountLot { get; set; }
        public decimal AmountTax { get; set; }
        public bool IsRelease { get; set; }
        public bool IsUseCheckingAccount { get; set; }
        public bool IsProcessed { get; set; }
        public DateTime CreatedDate { get; set; }
        public int IdUserRelease { get; set; }
        public int IdUserCancel { get; set; }
        public List<TransferRegister> TransferRegisters { get; set; }
        public string BankSlipUrl { get; set; }
    }
}