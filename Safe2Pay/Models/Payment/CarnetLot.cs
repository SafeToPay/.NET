using System;
using System.Collections.Generic;

namespace Safe2Pay.Models
{
    public class CarnetLot
    {
        public int Id { get; set; }
        public int IdMerchant { get; set; }
        public Merchant Merchant { get; set; }
        public string JsonGzip { get; set; }
        public string Identifier { get; set; }
        public string CallbackUrl { get; set; }
        public bool IsProcessed { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Transaction<Carnet>> Items { get; set; }
        public List<CarnetItems> Carnets { get; set; }
        public int ApiVersion { get; set; }
    }
}