using FastFood.Services.Models.Employees;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastFood.Services.Contracts
{
    public interface IEmployeeService
    {
        Task Add(CreateEmployeeDto dto);

        Task<ICollection<ListEmployeeDto>> GetAll();
    }
}
