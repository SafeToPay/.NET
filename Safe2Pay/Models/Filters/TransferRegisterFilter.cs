using System;

namespace Safe2Pay.Models
{
    public class TransferRegisterFilter : Filter<TransferRegister>
    {
        public DateTime CompensationDateInitial { get; set; }
        public DateTime CompensationDateEnd { get; set; }
        public DateTime CreatedDateInitial { get; set; }
        public DateTime CreatedDateEnd { get; set; }
        public bool? IsTransferred { get; set; }
        public bool? IsReleaseTransfer { get; set; }
    }
}