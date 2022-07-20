using Newtonsoft.Json;

namespace ProductShop.DTOs.Categories
{
    public class ImportCategoryDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
