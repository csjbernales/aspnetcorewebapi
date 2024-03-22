namespace aspnetcorewebapisqlclient.Business
{
    public class GetAllEmployee(IEmployeeService employeeService) : IGetAllEmployee
    {
        public async Task<List<Employees>> GetAllEmployees()
        {
            return await employeeService.Get();
        }
    }
}
