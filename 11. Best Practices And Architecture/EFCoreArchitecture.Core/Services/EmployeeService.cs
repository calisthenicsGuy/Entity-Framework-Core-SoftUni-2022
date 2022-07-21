using EFCoreArchitecture.Core.Contracts;
using EFCoreArchitecture.Core.Models;
using EFCoreArchitecture.Infrastructure.Data;
using EFCoreArchitecture.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreArchitecture.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ISoftUniRepository repo;

        public EmployeeService(ISoftUniRepository _repo)
        {
            repo = _repo;
        }

        public async Task<EmployeeModel> GetEmployeeWithHigherSalary()
        {
            return await repo.AllReadonly<Employees>()
                .Select(e => new EmployeeModel()
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Salary = e.Salary
                })
                .OrderByDescending(e => e.Salary)
                .FirstOrDefaultAsync();
        }
    }
}