namespace aspnetcorewebapisqlclient.Business
{
    public class RemoveEmployee(IEmployeeService employeeService) : IRemoveEmployee
    {
        public async Task<List<Employees>> RemoveEmployeeData(Employees employees)
        {
            return await employeeService.Delete(employees);
        }
    }
}
