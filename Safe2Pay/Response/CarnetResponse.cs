using System.Collections.Generic;

namespace Safe2Pay.Response
{
    public class CarnetResponse
    {
        public string CarnetUrl { get; set; }
        public string Identifier { get; set; }
        public List<BankSlipResponse> BankSlips { get; set; }
    }
}