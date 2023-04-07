namespace aspnetcorewebapisqlclient.Business
{
    public class AddNewEmployee : IAddNewEmployee
    {
        private readonly IEmployeeService employeeService;

        public AddNewEmployee(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public async Task<List<Employees>> AddEmployee(Employees employees)
        {
            return await employeeService.Post(employees);
        }
    }
}
