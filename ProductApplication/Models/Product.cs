using System.Text.Json.Serialization;

namespace ProductApplication.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockAvailable { get; set; }
    }
}
