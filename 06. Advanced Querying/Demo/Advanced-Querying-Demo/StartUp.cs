using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Advanced_Querying_Demo.Data.Models;
using Z.EntityFramework.Plus;

namespace Advanced_Querying_Demo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            // 1. Executing Native SQL Queries
            using SoftUniContext context = new SoftUniContext();

            string employeesQuery = "SELECT * FROM Employees";
            var employees = context.Employees
            .FromSqlRaw(employeesQuery)
            .ToArray();

            //foreach (var employee in employees)
            //{
            //    Console.WriteLine(employee.FirstName + " " + employee.LastName);
            //}

            int employeeId = 10;
            var employeeWithGivenId = context.Employees
                .FromSqlInterpolated($"SELECT * FROM [Employees] WHERE [EmployeeId] <= {employeeId}");

            //foreach (var employee in employeeWithGivenId)
            //{
            //    Console.WriteLine(employee.FirstName + " " + employee.LastName);
            //}


            Console.WriteLine();


            // 2. Object State Tracking
            /*
            foreach (var employee in employeeWithGivenId)
            {
                context.Entry(employee).State = EntityState.Modified; // Will be changed

                employee.JobTitle = "------------";

                Console.WriteLine(employee.FirstName + " " + employee.LastName + " " + employee.JobTitle);

            }
            context.SaveChanges();
            */

            /*
            foreach (var employee in employeeWithGivenId)
            {
                context.Entry(employee).State = EntityState.Detached; // Will not be changed

                employee.JobTitle = "!!!!!!!!!!!!!!!!!!";

                Console.WriteLine(employee.FirstName + " " + employee.LastName + " " + employee.JobTitle);

            }
            context.SaveChanges();
            */


            Console.WriteLine();


            // 3. Bulk Operations -> Install Z.EntityFramework.Plus.EFCore package

            // context.Employees.Where(e => e.EmployeeId <= 10).Delete();
            // context.SaveChanges();

            /*
            context.Employees
                .Where(e => e.EmployeeId <= 20)
                .Update(e => new Employee { JobTitle = "/////////////" });
            context.SaveChanges();
            */


            Console.WriteLine();


            // 4. Types of Loading:

                // Explicit Loading: 
                /*
                foreach (var employee in employees)
                {
                    context.Entry(employee).Reference(x => x.Department).Load();
                    Console.WriteLine(employee.Department.Name);
                } 
                */


                // Eager Loading -> with Inclide();
                

                // Lazy Loading: Install Microsoft.EntityFrameworkCore.Proxies
                // First step: vitual navigation properties
                // Second step: install Microsoft.EntityFrameworkCore.Proxies
                // Third step: active UseLazyLoadingProxies method in OnConfiguring method in DbContext class


            
            Console.WriteLine();


            // 5. Concurrency Checks:

            // 6. Cascade Operations

            context.Dispose();
        }
    }
}
