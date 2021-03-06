using Newtonsoft.Json;

namespace ProductShop.DTOs.Products
{
    [JsonObject]
    public class ExportSingleProductForUserDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
     
        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
