namespace aspnetcorewebapisqlclient.Business
{
    public class GetEmployeeById(IEmployeeService employeeService) : IGetEmployeeById
    {
        public async Task<List<Employees>> GetEmployee(int id)
        {
            return await employeeService.Get(id);
        }
    }
}
