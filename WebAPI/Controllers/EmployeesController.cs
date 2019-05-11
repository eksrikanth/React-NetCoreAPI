using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/Employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private ILogger _logger;
        public EmployeesController(IEmployeeRepository employeeRepository, ILoggerFactory factory)
        {
            _employeeRepository = employeeRepository;
            this._logger = factory.CreateLogger<EmployeesController>();
        }

        // GET api/Employees
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return _employeeRepository.GetAllEmployees().ToList();
        }

        // GET api/Employees/1
        [HttpGet("{Id}")]
        public ActionResult<Employee> Get(int Id)
        {
            return _employeeRepository.GetEmployee(Id);
        }

        // POST api/Employees
        [HttpPost]
        public ActionResult<Employee> POST([FromBody] Employee employee)
        {
            return _employeeRepository.AddEmployee(employee);
        }

        // PUT api/Employees
        [HttpPut]
        public ActionResult<Employee> PUT([FromBody] Employee employee)
        {
            return _employeeRepository.UpdateEmployee(employee);
        }

        [HttpDelete]
        public ActionResult<Employee> Delete([FromBody] Employee employee)
        {
            return _employeeRepository.UpdateEmployee(employee);
        }

    }
}