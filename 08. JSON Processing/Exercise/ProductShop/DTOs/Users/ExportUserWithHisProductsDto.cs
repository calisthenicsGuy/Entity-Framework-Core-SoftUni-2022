using Newtonsoft.Json;
using ProductShop.DTOs.Products;

namespace ProductShop.DTOs.Users
{
    public class ExportUserWithHisProductsDto
    {
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        
        [JsonProperty("age")]
        public int Age { get; set; }
        
        [JsonProperty("soldProducts")]
        public ExportAllProductsOfUserDto SoldProducts { get; set; }
    }
}
