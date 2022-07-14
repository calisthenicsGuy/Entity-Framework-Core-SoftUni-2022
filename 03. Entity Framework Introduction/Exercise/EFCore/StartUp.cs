namespace SoftUni
{
    using System;
    using System.Linq;
    using SoftUni.Data;
    using SoftUni.Models;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using System.Runtime.Serialization;

    public class StartUp
    {
        static void Main(string[] args)
        {
            using SoftUniContext context = new SoftUniContext();

            // P03: Console.WriteLine(GetEmployeesFullInformation(context));
            // P04: Console.WriteLine(GetEmployeesWithSalaryOver50000(context));
            // P05: Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));
            // P06: Console.WriteLine(AddNewAddressToEmployee(context));
            // P10: Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));
            // P11: Console.WriteLine(GetLatestProjects(context));
            // P12: Console.WriteLine(IncreaseSalaries(context));
            // P13: Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));
            // P14: Console.WriteLine(DeleteProjectById(context));
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

        // Problem 10: Departments with More Than 5 Employees
        private static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var targetDepartmentInformation = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(e => e.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFullName = $"{d.Manager.FirstName} {d.Manager.LastName}",
                    EmployeesInformation = d.Employees.Select(e => new
                    {
                        FullName = $"{e.FirstName} {e.LastName}",
                        JobTitle = e.JobTitle
                    })
                    //.OrderBy(n => n.FullName).ThenBy(j => j.JobTitle),
                });


            foreach (var department in targetDepartmentInformation)
            {
                output.AppendLine($"{department.DepartmentName} - {department.ManagerFullName}");

                foreach (var employee in department.EmployeesInformation
                    .OrderBy(n => n.FullName).ThenBy(j => j.JobTitle))
                {
                    output.AppendLine($"{employee.FullName} - {employee.JobTitle}");
                }
            }

            return output.ToString().TrimEnd();
        }

        // Problem 11: Find Latest 10 Projects
        private static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var targetProjects = context.Projects
                .OrderByDescending(d => d.StartDate)
                .Take(10)
                .Select(e => new
                {
                    e.Name,
                    e.Description,
                    e.StartDate
                })
                .OrderBy(n => n.Name);

            foreach (var project in targetProjects)
            {
                output
                    .AppendLine($"{project.Name}")
                    .AppendLine($"{project.Description}")
                    .AppendLine($"{project.StartDate}")
                    .AppendLine(null);
            }

            return output.ToString().TrimEnd();
        }

        // Problem 12: Increase Salaries
        private static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            string[] departments = new string[]
            {
                "Engineering", "Tool Design", "Marketing", "Information Services"
            };

            var targetEmployees = context.Employees
                .Where(d => departments.Contains(d.Department.Name))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    Salary = e.Salary / (decimal)0.88
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var employee in targetEmployees)
            {
                output.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        // Problem 13: Find Employees by First Name Starting with "Sa"
        private static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var output = new StringBuilder();

            var employees = context
                    .Employees
                    .Where(e => e.FirstName.StartsWith("Sa"))
                    .Select(e => new
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        JobTitle = e.JobTitle,
                        Salary = e.Salary
                    })
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName);

            foreach (var e in employees)
            {
                output.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return output.ToString().TrimEnd();
        }

        // Problem 14: Delete Project by Id
        private static string DeleteProjectById(SoftUniContext context)
        {
            var output = new StringBuilder();

            // First break the connection between EmployeesProjects and Projects for all progect with Id = 2
            var employeeProjects = context
                    .EmployeesProjects
                    .Where(ep => ep.ProjectId == 2);

            // Remove the poject from EmployeesProjects
            context
                .EmployeesProjects
                .RemoveRange(employeeProjects);

            // After that get all project with Id = 2 from Projects and remove it
            var projectWithId2 = context
                .Projects.Find(2);

            context
                .Projects
                .Remove(projectWithId2);

            // Save changes
            context.SaveChanges();

            // Get and Print the output
            var firstTenProjects = context
                .Projects
                .Take(10)
                .Select(p => p.Name);

            firstTenProjects.ForEachAsync(p => output.AppendLine(p));

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
            context.SaveChanges();

            // 5. Return the output
            return $"{addressToRemove.Count} addresses in Seattle were deleted";
        }
    }
}