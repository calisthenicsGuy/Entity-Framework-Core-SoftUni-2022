using Newtonsoft.Json;

namespace ProductShop.DTOs.Products
{
    public class ExportProductsForSoldProductsOfUserDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
