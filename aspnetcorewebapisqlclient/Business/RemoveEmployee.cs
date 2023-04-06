using aspnetcorewebapisqlclient.Business.Interfaces;
using aspnetcorewebapisqlclient.Data.Service;
using aspnetcorewebapisqlclient.Models.Business;

namespace aspnetcorewebapisqlclient.Business
{
    public class RemoveEmployee : IRemoveEmployee
    {
        private readonly IEmployeeService employeeService;

        public RemoveEmployee(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public async Task<List<Employees>> RemoveEmployeeData(int id)
        {
            return await employeeService.Delete(id);
        }
    }
}
