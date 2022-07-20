using Newtonsoft.Json;
using System.Linq;

namespace ProductShop.DTOs.Products
{
    [JsonObject]
    public class ExportSoldProductsForUserDto
    {
        [JsonProperty("count")]
        public int Count => this.Products.Any() ? this.Products.Length : 0;
        public ExportSingleProductForUserDto[] Products { get; set; }
    }
}
