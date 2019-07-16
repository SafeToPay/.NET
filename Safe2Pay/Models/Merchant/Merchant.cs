using System.Collections.Generic;

namespace Safe2Pay.Models
{
    public class Merchant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CommercialName  { get; set; }
        public string Identity { get; set; }
        public string ResponsibleName { get; set; }
        public string ResponsibleIdentity { get; set; }
        public string Email { get; set; }
        public string TechName { get; set; }
        public string TechIdentity { get; set; }
        public string TechEmail { get; set; }
        public string Token { get; set; }
        public string SecretKey { get; set; }
        public string TokenSandbox { get; set; }
        public string SecretKeySandbox { get; set; }
        public BankData BankData { get; set; }
        public Address Address { get; set; }
        public Configuration Configuration { get; set; }
        public List<MerchantSplit> MerchantSplit { get; set; }
        public bool IsRemoved { get; set; }
    }
}