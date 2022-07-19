using Newtonsoft.Json;
using ProductShop.DTOs.Products;
using System.Collections.Generic;

namespace ProductShop.DTOs.Users
{
    [JsonObject]
    public class ExportUserProductsDto
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("soldProducts")]
        public ExportSoldProductDto[] SoldProducts { get; set; }
    }
}
