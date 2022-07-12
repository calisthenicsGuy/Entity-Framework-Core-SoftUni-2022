namespace SoftUni
{
    using System;
    using System.Linq;
    using SoftUni.Data;
    using SoftUni.Models;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        static void Main(string[] args)
        {
            using SoftUniContext context = new SoftUniContext();

            // P03: Console.WriteLine(GetEmployeesFullInformation(context));
            // P04: Console.WriteLine(GetEmployeesWithSalaryOver50000(context));
            // P05: Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));
            // P06: Console.WriteLine(AddNewAddressToEmployee(context));
            // P15: Console.WriteLine(RemoveTown(context));


            context.Dispose();
        }

        // Problem 03: Employees Full Information
        private static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var employees = context.Employees
                .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.MiddleName,
                        e.JobTitle,
                        e.Salary
                    })
                .ToList();

            foreach (var employee in employees)
            {
                output.AppendLine
                    ($"{employee.FirstName} " +
                    $"{employee.LastName} " +
                    $"{employee.MiddleName} " +
                    $"{employee.JobTitle} " +
                    $"{employee.Salary:f2} ");
            }

            return output.ToString().TrimEnd();
        }


        // Problem 04: Employees with Salary Over 50 000
        private static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var targetEmployees = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new { e.FirstName, e.Salary })
                .OrderBy(x => x.FirstName)
                .ToList();

            string queryText = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new { e.FirstName, e.Salary })
                .OrderBy(x => x.FirstName)
                .ToQueryString();

            foreach (var employee in targetEmployees)
            {
                output.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return output.ToString().TrimEnd();
        }

        // Problem 05: Employees from Research and Development
        private static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var targetEmployees = context.Employees
                .Where(d =>
                    d.Department.Name == "Research and Development")
                .Select(e => new { e.FirstName, e.LastName, e.Department.Name, e.Salary })
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .ToList();

            foreach (var employee in targetEmployees)
            {
                output.AppendLine(
                    $"{employee.FirstName} {employee.LastName} from Research and Development - ${employee.Salary:f2}");
            }

            return output.ToString().TrimEnd();
        }

        // Problem 06: Adding a New Address and Updating Employee
        private static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            Address address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            List<string> targetEmployees = context.Employees
                .Where(n => n.LastName == "Nakov")
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .Select(a => a.Address.AddressText)
                .ToList();

            foreach (string employeeAddress in targetEmployees)
            {
                output.AppendLine(employeeAddress);
            }

            return output.ToString().TrimEnd();
        }

        // Problem 15: Remove Town
        private static string RemoveTown(SoftUniContext context)
        {

            // 1. Get and Set address of all employees that living in the Seattle to null
            var employeesThatLivinInSeattleCity = context.Employees
                .Where(a => a.Address.Town.Name == "Seattle")
                .ToList();

            foreach (var employee in employeesThatLivinInSeattleCity)
            {
                employee.AddressId = null;
            }

            // 2. Get and Remove all addresses in the Seattle
            var addressToRemove = context.Addresses
                .Where(a => a.Town.Name == "Seattle").ToList();

            foreach (var address in addressToRemove)
            {
                context.Addresses.Remove(address);
            }

            // 3. Get and Remove Seattle City
            Town townToRemove = (Town)context.Towns.Where(n => n.Name == "Seattle");
            context.Towns.Remove(townToRemove);

            // 4. Save changes to database
            // context.SaveChanges();

            // 5. Return the output
            return $"{addressToRemove.Count} addresses in Seattle were deleted";
        }
    }
}
