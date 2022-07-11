using ORM_Fundamentals_Demo.Data;
using ORM_Fundamentals_Demo.Data.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ORM_Fundamentals_Demo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using SoftUniDbContext softUniDb = new SoftUniDbContext();

            //Department it = new Department()
            //{
            //    Name = "IT"
            //};

            //Department hr = new Department()
            //{
            //    Name = "HR"
            //};

            //Department pr = new Department()
            //{
            //    Name = "PR"
            //};

            //softUniDb.Departments.Add(it);
            //softUniDb.Departments.Add(hr);
            //softUniDb.Departments.Add(pr);

            //Employee employee1 = new Employee()
            //{
            //    FirstName = "Petar",
            //    LastName = "Petrov",
            //    JobTitle = "Junior C# dev",
            //    Department = it
            //};

            //Employee employee2 = new Employee()
            //{
            //    FirstName = "Gosho",
            //    LastName = "Goshev",
            //    JobTitle = "Recruiter",
            //    Department = hr
            //};

            //Employee employee3 = new Employee()
            //{
            //    FirstName = "Maria",
            //    LastName = "Marinova",
            //    JobTitle = "PR",
            //    Department = pr
            //};

            //softUniDb.Employees.Add(employee1);
            //softUniDb.Employees.Add(employee2);
            //softUniDb.Employees.Add(employee3);


            //softUniDb.SaveChanges();
            //System.Console.WriteLine("Added success");


            softUniDb.Employees.FirstOrDefault(x => x.DepartmentID == 1).FirstName = "Pesho";
            softUniDb.SaveChanges();

            var employyesThatWorkInDepartmentWithIdOne = softUniDb.Employees.Where(x => x.DepartmentID == 1).ToList();

            foreach (Employee employee in employyesThatWorkInDepartmentWithIdOne)
            {
                System.Console.WriteLine($"{employee.FirstName} - {employee.LastName} - {employee.JobTitle}");
            }


            Employee employeeWithIdOne = softUniDb.Employees.Find(1); // Find by default search with Id
        }
    }
}