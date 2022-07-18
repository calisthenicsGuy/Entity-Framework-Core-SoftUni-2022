
using FastFood.Services.Models.Items;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastFood.Services.Contracts
{
    public interface IItemService
    {
        Task Add(CreateItemDto dto);

        Task<ICollection<ListItemDto>> GetAll();
    }
}
