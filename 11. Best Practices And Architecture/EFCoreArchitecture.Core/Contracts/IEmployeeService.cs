using EFCoreArchitecture.Core.Models;
using System.Threading.Tasks;

namespace EFCoreArchitecture.Core.Contracts
{
    public interface IEmployeeService
    {
        Task<EmployeeModel> GetEmployeeWithHigherSalary();
    }
}
