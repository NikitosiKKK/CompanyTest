using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("")]
        public ActionResult<List<EmployeeModel>> List()
        {
            var employees = _employeeService.List();

            return Ok(employees);
        }

        [HttpGet("{id:int}")]
        public ActionResult<EmployeeModel> Get(int id)
        {
            var employee = _employeeService.Get(id);

            return Ok(employee);
        }
        [HttpPost("{id:int}")]
        public ActionResult<EmployeeModel> Update(int id, EmployeeUpdateModel employeeModel)
        {
            var employee = _employeeService.Update(id, employeeModel);

            return employee;
        }
        [HttpPost("")]
        public ActionResult<EmployeeModel> Create([FromBody]EmployeeModel employeeModel)
        {
            var employee = _employeeService.Create(employeeModel);

            return employee;
        }
        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            _employeeService.Delete(id);
        }
    }
}
