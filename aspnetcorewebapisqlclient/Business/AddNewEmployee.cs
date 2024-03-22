namespace aspnetcorewebapisqlclient.Business
{
    public class AddNewEmployee(IEmployeeService employeeService) : IAddNewEmployee
    {
        public async Task<List<Employees>> AddEmployee(Employees employees)
        {
            return await employeeService.Post(employees);
        }
    }
}
