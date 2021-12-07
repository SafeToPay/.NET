﻿namespace Safe2Pay.Models
{
    public class DebitCard
    {
        public string Holder { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public string SoftDescriptor { get; set; }
        public string ReturnUrl { get; set; }
    }
}