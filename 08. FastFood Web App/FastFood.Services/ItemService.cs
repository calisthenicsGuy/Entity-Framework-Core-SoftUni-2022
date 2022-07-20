using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Data;
using FastFood.Models;
using FastFood.Services.Contracts;
using FastFood.Services.Models.Items;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastFood.Services
{
    public class ItemService : IItemService
    {
        private readonly FastFoodContext dbContext;
        private readonly IMapper mapper;

        public ItemService(FastFoodContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task Add(CreateItemDto dto)
        {
            Item item = this.mapper.Map<Item>(dto);

            await this.dbContext.Items.AddAsync(item);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<ListItemDto>> GetAll()
        {
            ICollection<ListItemDto> itemDtos = await this.dbContext
                .Items
                .ProjectTo<ListItemDto>(this.mapper.ConfigurationProvider)
                .ToArrayAsync();

            return itemDtos;
        }
    }
}
