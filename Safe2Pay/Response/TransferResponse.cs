using System;
using Safe2Pay.Models;

namespace Safe2Pay.Response
{
    public class TransferResponse
    {
        public int Id { get; set; }
        public BankData BankData { get; set; }
        public string ReceiverName { get; set; }
        public string Identity { get; set; }
        public double Amount { get; set; }
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
        public string ValidationSimplify { get; set; }
        public object BankingTransferOccurrenceReason { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public string BankSlipNumber { get; set; }
        public string DueDate { get; set; }
        public string DigitableLine { get; set; }
        public string Barcode { get; set; }
        public string BankSlipUrl { get; set; }
        public double AmountLot { get; set; }
        public double AmountTax { get; set; }
        public bool IsRelease { get; set; }
        public bool IsUseCheckingAccount { get; set; }
        public bool IsProcessed { get; set; }
    }
}