using Newtonsoft.Json;
using ProductShop.DTOs.Products;

namespace ProductShop.DTOs.Users
{
    [JsonObject]
    public class ExportUsersWithHisProductsDto
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        
        [JsonProperty("age")]
        public int? Age { get; set; }

        [JsonProperty("soldProducts")]
        public ExportSoldProductsForUserDto SoldProducts { get; set; }
    }
}
