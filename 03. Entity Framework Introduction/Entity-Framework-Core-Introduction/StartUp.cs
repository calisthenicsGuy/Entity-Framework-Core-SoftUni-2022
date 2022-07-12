using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entity_Framework_Core_Introduction.Models;
using System.Collections;

namespace Entity_Framework_Core_Introduction
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            using SoftUniContext dbContext = new SoftUniContext();

            Employee firstEmployee = await dbContext.Employees.FindAsync(5);

            var secondEmployee = await dbContext.Employees
                .Include(a => a.Address)
                .ThenInclude(t => t.Town)
                .FirstOrDefaultAsync();
            ;
        }
    }
}