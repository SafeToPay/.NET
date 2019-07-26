using System;
using System.Collections.Generic;

namespace Safe2Pay.Models
{
    public class TransferRegister
    {
        public int Id { get; set; }
        public int IdTransfer { get; set; }
        public int IdMerchant { get; set; }
        public BankData BankData { get; set; }
        public string ReceiverName { get; set; }
        public string Identity { get; set; }
        public decimal Amount { get; set; }
        public string Identification { get; set; }
        public string CallbackUrl { get; set; }
        public bool IsTransferred { get; set; }
        public bool IsReleaseTransfer { get; set; }
        public bool IsNotified { get; set; }
        public bool IsReturned { get; set; }
        public string HashScheduling { get; set; }
        public string HashConfirmation { get; set; }
        public DateTime CompensationDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ChangedDate { get; set; }
        public string Validation { get; set; }
        public List<BankingTransferOccurrenceReason> BankingTransferOccurrenceReason { get; set; }
        public int IdMerchantRequester { get; set; }
        public int IdTransferRegisterLot { get; set; }
    }
}