using Microsoft.AspNetCore.Mvc;

namespace aspnetcorewebapisqlclient.Controllers
{
    [ApiController]
    [Route("[controller]")] //Employees
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeDependency employeeDependency;

        public EmployeesController(IEmployeeDependency employeeDependency)
        {
            this.employeeDependency = employeeDependency;
        }
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            return Ok(await employeeDependency.Get());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await employeeDependency.Get(id));
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] Employees employee)
        {
            return Ok(await employeeDependency.Post(employee));
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] Employees employee)
        {
            return Ok(await employeeDependency.Put(employee));
        }

        [HttpDelete()]
        public async Task<IActionResult> Delete(Employees employees)
        {
            return Ok(await employeeDependency.Delete(employees));
        }
    }
}