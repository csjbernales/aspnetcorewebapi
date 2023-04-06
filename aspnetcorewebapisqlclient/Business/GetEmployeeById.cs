using aspnetcorewebapisqlclient.Business.Interfaces;
using aspnetcorewebapisqlclient.Data.Service;
using aspnetcorewebapisqlclient.Models.Business;

namespace aspnetcorewebapisqlclient.Business
{
    public class GetEmployeeById : IGetEmployeeById
    {
        private readonly IEmployeeService employeeService;

        public GetEmployeeById(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public async Task<List<Employees>> GetEmployee(int id)
        {
            return await employeeService.Get(id);
        }
    }
}
