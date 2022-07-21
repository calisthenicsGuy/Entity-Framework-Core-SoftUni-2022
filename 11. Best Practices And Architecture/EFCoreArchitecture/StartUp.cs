using EFCoreArchitecture.Core.Contracts;
using EFCoreArchitecture.Core.Services;
using EFCoreArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace EFCoreArchitecture
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<SoftUniContext>(options => 
                options.UseSqlServer("Server=.;Database=SoftUni;User Id=sa;Password=SoftUn!2021;"))
                .AddScoped<ISoftUniRepository, SoftUniRepository>()
                .AddScoped<IEmployeeService, EmployeeService>()
                .BuildServiceProvider();

            var employeeService = serviceProvider.GetService<IEmployeeService>();
            var employee = await employeeService.GetEmployeeWithHigherSalary();

            Console.WriteLine($"{employee.FirstName} {employee.LastName}: {employee.Salary}");

        }
    }
}
