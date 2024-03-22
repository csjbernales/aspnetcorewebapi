namespace aspnetcorewebapisqlclient.Controllers
{
    public class EmployeeDependency(IGetAllEmployee getAllEmployee, IGetEmployeeById getEmployeeById, IAddNewEmployee addNewEmployee, IUpdateEmployee updateEmployee, IRemoveEmployee removeEmployee) : IEmployeeDependency
    {
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
