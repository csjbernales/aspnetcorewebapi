using aspnetcorewebapisqlclient.Models.Business;

namespace aspnetcorewebapisqlclient.Business
{
    public class UpdateEmployee : IUpdateEmployee
    {
        private readonly IEmployeeService employeeService;

        public UpdateEmployee(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public async Task<List<Employees>> UpdateEmployeeData(Employees employees)
        {
            return await employeeService.Put(employees);
        }
    }
}
