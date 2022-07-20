using Newtonsoft.Json;
using System.Linq;

namespace ProductShop.DTOs.Users
{
    [JsonObject]
    public class ExportUsersInfo
    {
        [JsonProperty("usersCount")]
        public int UsersCount => this.Users.Any() ? this.Users.Length : 0;

        [JsonProperty("users")]
        public ExportUsersWithHisProductsDto[] Users { get; set; }
    }
}
