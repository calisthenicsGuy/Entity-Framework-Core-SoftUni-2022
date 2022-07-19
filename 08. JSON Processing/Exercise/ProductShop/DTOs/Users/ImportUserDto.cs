using Newtonsoft.Json;

namespace ProductShop.DTOs.Users
{
    public class ImportUserDto
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }
        
        [JsonProperty("age")]
        public int? Age { get; set; }
    }
}
