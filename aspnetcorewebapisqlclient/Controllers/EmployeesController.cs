using Microsoft.AspNetCore.Mvc;

namespace aspnetcorewebapisqlclient.Controllers
{
    [ApiController]
    [Route("[controller]")] //Employees
    public class EmployeesController : ControllerBase
    {
        private readonly IGetAllEmployee getAllEmployee;
        private readonly IGetEmployeeById getEmployeeById;
        private readonly IAddNewEmployee addNewEmployee;
        private readonly IUpdateEmployee updateEmployee;
        private readonly IRemoveEmployee removeEmployee;


        public EmployeesController(IGetAllEmployee getAllEmployee, IGetEmployeeById getEmployeeById, IAddNewEmployee addNewEmployee, IUpdateEmployee updateEmployee, IRemoveEmployee removeEmployee)
        {
            this.getAllEmployee = getAllEmployee;
            this.getEmployeeById = getEmployeeById;
            this.addNewEmployee = addNewEmployee;
            this.updateEmployee = updateEmployee;
            this.removeEmployee = removeEmployee;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            return Ok(await getAllEmployee.GetAllEmployees());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await getEmployeeById.GetEmployee(id));
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] Employees employee)
        {
            return Ok(await addNewEmployee.AddEmployee(employee));
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] Employees employee)
        {
            return Ok(await updateEmployee.UpdateEmployeeData(employee));
        }

        [HttpDelete()]
        public async Task<IActionResult> Delete(Employees employees)
        {
            return Ok(await removeEmployee.RemoveEmployeeData(employees));
        }
    }
}