using System.Collections.Generic;
using Safe2Pay.Models;

namespace Safe2Pay.Response
{
    public class MarketplaceResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CommercialName { get; set; }
        public string ResponsibleName { get; set; }
        public string ResponsibleIdentity { get; set; }
        public string Email { get; set; }
        public string Identity { get; set; }
        public Integration Integration { get; set; }
        public string Token { get; set; }
        public BankDataResponse BankData { get; set; }
        public AddressResponse Address { get; set; }
        public List<PaymentMethodResponse> PaymentMethods { get; set; }
    }
}