using Newtonsoft.Json;

namespace ProductShop.DTOs.Products
{
    public class ExportAllProductsOfUserDto
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("products")]
        public ExportProductsForSoldProductsOfUserDto[] Products { get; set; }
    }
}
