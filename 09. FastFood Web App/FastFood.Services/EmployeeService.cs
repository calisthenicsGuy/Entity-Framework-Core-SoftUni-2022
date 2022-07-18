using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Data;
using FastFood.Models;
using FastFood.Services.Contracts;
using FastFood.Services.Models.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly FastFoodContext dbContext;
        private readonly IMapper mapper;

        public EmployeeService(FastFoodContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task Add(CreateEmployeeDto dto)
        {
            Employee employee = mapper.Map<Employee>(dto);

            await this.dbContext.Employees.AddAsync(employee);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<ListEmployeeDto>> GetAll()
        {
            ICollection<ListEmployeeDto> employeeDtos = await this.dbContext
                .Employees
                .ProjectTo<ListEmployeeDto>(this.mapper.ConfigurationProvider)
                .ToArrayAsync();

            return employeeDtos;
        }
    }
}
