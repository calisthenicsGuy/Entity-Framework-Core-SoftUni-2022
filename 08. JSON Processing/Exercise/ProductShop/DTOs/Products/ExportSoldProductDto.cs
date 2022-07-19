using Newtonsoft.Json;

namespace ProductShop.DTOs.Products
{
    [JsonObject]
    public class ExportSoldProductDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("price")]
        public decimal Prie { get; set; }

        [JsonProperty("buyerFirstName")]
        public string BuyerFirstName { get; set; }
        
        [JsonProperty("buyerLastName")]
        public string BuyerLastName { get; set; }
    }
}
