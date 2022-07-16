using System;
using AutoMapper;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using Auto_Mapping_Objects_Demo_01.Data.Models;
using AutoMapper.QueryableExtensions;

namespace Auto_Mapping_Objects_Demo_01
{
    public class EmployeeInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string DepartmentName { get; set; }
    }

    public class ProjectInfo
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class DepartmentInfo
    {
        public string Name { get; set; }

        public string Manager { get; set; }
        public int EmployeesCount { get; set; }
    }

    public class StartUp
    {
        static void Main(string[] args)
        {
            #region
            using SoftUniContext context = new SoftUniContext();

            //IEnumerable<EmployeeInfo> employees = GetEmployeeInfo(context);
            //Console.WriteLine(JsonConvert.SerializeObject(employees, Formatting.Indented));
            //// Writer.Write(JsonConvert.SerializeObject(employees, Formatting.Indented));

            //Console.WriteLine();

            //IEnumerable<ProjectInfo> projects = GetProjectInfo(context);
            //Console.WriteLine(JsonConvert.SerializeObject(projects, Formatting.Indented));
            #endregion

            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<Employee, EmployeeInfo>();
                config.CreateMap<Project, ProjectInfo>();
                config.CreateMap<Department, DepartmentInfo>()
                      .ForMember(x => x.Manager, options => 
                      options.MapFrom(x => $"{x.Manager.FirstName} {x.Manager.LastName}")); // Custom Mapping 
            });
            var mapper = config.CreateMapper();

            Employee employee = context.Employees
                .Where(e => e.JobTitle.ToLower().Contains("technician"))
                .FirstOrDefault();

            EmployeeInfo employeeDto = mapper.Map<EmployeeInfo>(employee);
            // Console.WriteLine(JsonConvert.SerializeObject(employeeDto, Formatting.Indented));

            
            Project project = context.Projects
                .Where(p => p.Name.ToLower().Contains("o"))
                .FirstOrDefault();

            ProjectInfo projectDto = mapper.Map<ProjectInfo>(project);
            // Console.WriteLine(JsonConvert.SerializeObject(projectDto, Formatting.Indented));


            var employeesDto = context.Employees
                .Where(e => e.JobTitle.ToLower().Contains("technician"))
                .ProjectTo<EmployeeInfo>(config)
                .ToList();
            // Console.WriteLine(JsonConvert.SerializeObject(employeesDto, Formatting.Indented));

            IEnumerable<DepartmentInfo> departmentsDto = context.Departments
                .Where(d => d.Name.ToLower().Contains("d"))
                .ProjectTo<DepartmentInfo>(config);
            Console.WriteLine(JsonConvert.SerializeObject(departmentsDto, Formatting.Indented));


        }

        public static IEnumerable<EmployeeInfo> GetEmployeeInfo(SoftUniContext context)
        {
            return context.Employees
                .Where(e => e.JobTitle.ToLower().Contains("technician"))
                .Select(e => new EmployeeInfo()
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    DepartmentName = e.Department.Name
                })
                .ToList();
        }

        public static IEnumerable<ProjectInfo> GetProjectInfo(SoftUniContext context)
        {
            return context.Projects
                .Where(p => p.Name.ToLower().Contains("o"))
                .Select(p => new ProjectInfo()
                {
                    Name = p.Name,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate
                });
        }
    }
}