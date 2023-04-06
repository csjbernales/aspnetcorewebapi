using aspnetcorewebapisqlclient.Models.Business;

namespace aspnetcorewebapisqlclient.Business
{
    public class GetAllEmployee : IGetAllEmployee
    {
        private readonly IEmployeeService employeeService;

        public GetAllEmployee(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public async Task<List<Employees>> GetAllEmployees()
        {
            return await employeeService.Get();
        }
    }
}
