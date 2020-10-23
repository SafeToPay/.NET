using System.Collections.Generic;

namespace Safe2Pay.Models
{
    public class Merchant
    {
        public string Name { get; set; }
        public string CommercialName  { get; set; }
        public string Identity { get; set; }
        public string ResponsibleName { get; set; }
        public string ResponsibleIdentity { get; set; }
        public string Email { get; set; }
        public string TechName { get; set; }
        public string TechIdentity { get; set; }
        public string TechEmail { get; set; }
        public bool IsPanelRestricted { get; set; }
        public BankData BankData { get; set; }
        public Address Address { get; set; }
        public List<MerchantSplit> MerchantSplit { get; set; }
        public Bank Bank { get; set; }
        public AccountType AccountType  { get; set; }
    }
}