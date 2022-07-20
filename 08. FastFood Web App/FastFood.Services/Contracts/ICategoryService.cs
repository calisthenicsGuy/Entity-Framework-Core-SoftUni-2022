using FastFood.Services.Models.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastFood.Services.Contracts
{
    public interface ICategoryService
    {
        Task Add(CreateCategoryDto categoryDto);

        Task<ICollection<ListCategoryDto>> GetAll();

        Task<bool> ExistsById(int id);
    }
}
