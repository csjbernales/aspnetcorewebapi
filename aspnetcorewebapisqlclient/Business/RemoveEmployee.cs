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

        public async Task<List<Employees>> RemoveEmployeeData(Employees employees)
        {
            return await employeeService.Delete(employees);
        }
    }
}
