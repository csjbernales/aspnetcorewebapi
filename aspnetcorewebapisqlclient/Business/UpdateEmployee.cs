namespace aspnetcorewebapisqlclient.Business
{
    public class UpdateEmployee(IEmployeeService employeeService) : IUpdateEmployee
    {
        public async Task<List<Employees>> UpdateEmployeeData(Employees employees)
        {
            return await employeeService.Put(employees);
        }
    }
}
