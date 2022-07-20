namespace FastFood.Core.Controllers
{
    using System;
    using AutoMapper;
    using Data;
    using FastFood.Services.Contracts;
    using FastFood.Services.Models.Employees;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Employees;

    public class EmployeesController : Controller
    {
        // TODO: Connection with position of the employee


        private IEmployeeService employeeService;
        private readonly IMapper mapper;

        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            this.employeeService = employeeService;
            this.mapper = mapper;
        }

        public IActionResult Register()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterEmployeeInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(Register), "Employees");
            }



            CreateEmployeeDto employee = this.mapper.Map<CreateEmployeeDto>(model);
            
            // TODO: redirect to action
        }

        // TODO
        public IActionResult All()
        {
            throw new NotImplementedException();
        }
    }
}
