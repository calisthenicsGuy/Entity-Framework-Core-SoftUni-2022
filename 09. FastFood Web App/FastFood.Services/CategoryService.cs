using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Data;
using FastFood.Models;
using FastFood.Services.Contracts;
using FastFood.Services.Models.Categories;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFood.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly FastFoodContext dbContext;
        private readonly IMapper mapper;

        public CategoryService(FastFoodContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task Add(CreateCategoryDto categoryDto)
        {
            Category category = this.mapper.Map<Category>(categoryDto);

            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsById(int id)
        {
            return await this.dbContext
                .Categories
                .AnyAsync(c => c.Id == id);
        }

        public async Task<ICollection<ListCategoryDto>> GetAll()
        {
            ICollection<ListCategoryDto> result = await this.dbContext
                .Categories
                .ProjectTo<ListCategoryDto>(this.mapper.ConfigurationProvider)
                .ToArrayAsync();

            return result;
        }
    }
}
