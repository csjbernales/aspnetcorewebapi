using aspnetcorewebapisqlclient.Models;
using aspnetcorewebapisqlclient.Service;

using Microsoft.AspNetCore.Mvc;

namespace aspnetcorewebapisqlclient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet(Name = "GetEmployees")]
        public async Task<IActionResult> Get()
        {
            return Ok(await employeeService.Get());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await employeeService.Get(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Employees employee)
        {
            return Ok(await employeeService.Put(id, employee));
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] Employees employee)
        {
            return Ok(await employeeService.Post(employee));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await employeeService.Delete(id));
        }
    }
}