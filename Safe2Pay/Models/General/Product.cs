using Newtonsoft.Json;

namespace Safe2Pay
{
    public class Product
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
    }
}