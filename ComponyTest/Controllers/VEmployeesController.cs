using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class VEmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public VEmployeesController(IEmployeeService employeeService)
        {
            _employeeService= employeeService;
        }
        public IActionResult Employees()
        {
            var employees = _employeeService.List();
            ViewBag.Employees = employees;

            return View("Employees");
        }

        public IActionResult Employee(int id)
        {
            var employee = _employeeService.Get(id);
            ViewBag.Employee = employee;
            return View();
        }
        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {
            var employee = _employeeService.Get(id);
            ViewBag.Employee = employee;
            return View();
        }
        [HttpPost]
        public IActionResult UpdateEmployee(int id, EmployeeUpdateModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                var employee = _employeeService.Update(id, employeeModel);
                return View("UpdatedEmployee");
            }
            return View(employeeModel);
        }
         [HttpGet]
         public IActionResult DeleteEmployee(int id)
         {
             var employee = _employeeService.Get(id);
             return View(employee);
         }
         [HttpPost]
         public IActionResult DeleteEmployee(int id, string s)
         {
             _employeeService.Delete(id);
             return View("DeletedEmployee");
         }
        [HttpGet]
         public IActionResult AddEmployee()
         {
             return View();

         }
         [HttpPost]
         public IActionResult AddEmployee(EmployeeModel employeeModel)
         {
             if (ModelState.IsValid)
             {
                 var employee = _employeeService.Create(employeeModel);
                 return Employees();
             }
             return View(employeeModel);
         }
    }
}

