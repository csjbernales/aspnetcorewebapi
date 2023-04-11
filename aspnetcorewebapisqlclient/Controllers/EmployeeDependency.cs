namespace aspnetcorewebapisqlclient.Controllers
{
    public class EmployeeDependency : IEmployeeDependency
    {
        private readonly IGetAllEmployee getAllEmployee;
        private readonly IGetEmployeeById getEmployeeById;
        private readonly IAddNewEmployee addNewEmployee;
        private readonly IUpdateEmployee updateEmployee;
        private readonly IRemoveEmployee removeEmployee;

        public EmployeeDependency(IGetAllEmployee getAllEmployee, IGetEmployeeById getEmployeeById, IAddNewEmployee addNewEmployee, IUpdateEmployee updateEmployee, IRemoveEmployee removeEmployee)
        {
            this.getAllEmployee = getAllEmployee;
            this.getEmployeeById = getEmployeeById;
            this.addNewEmployee = addNewEmployee;
            this.updateEmployee = updateEmployee;
            this.removeEmployee = removeEmployee;
        }

        public async Task<List<Employees>> Get()
        {
            return await getAllEmployee.GetAllEmployees();
        }

        public async Task<List<Employees>> Get(int id)
        {
            return await getEmployeeById.GetEmployee(id);
        }

        public async Task<List<Employees>> Post(Employees employees)
        {
            return await addNewEmployee.AddEmployee(employees);
        }

        public async Task<List<Employees>> Put(Employees employees)
        {
            return await updateEmployee.UpdateEmployeeData(employees);
        }

        public async Task<List<Employees>> Delete(Employees employees)
        {
            return await removeEmployee.RemoveEmployeeData(employees);
        }
    }
}
