using aspnetcorewebapisqlclient.Business.Interfaces;

namespace aspnetcorewebapisqlclient.Controllers.Tests
{
    [TestClass()]
    public class EmployeeDependencyTests
    {
        private IGetAllEmployee getAllEmployee;
        private IGetEmployeeById getEmployeeById;
        private IAddNewEmployee addNewEmployee;
        private IUpdateEmployee updateEmployee;
        private IRemoveEmployee removeEmployee;

        [TestInitialize]
        public void Setup()
        {
            this.getAllEmployee = A.Fake<IGetAllEmployee>();
            this.getEmployeeById = A.Fake<IGetEmployeeById>();
            this.addNewEmployee = A.Fake<IAddNewEmployee>();
            this.updateEmployee = A.Fake<IUpdateEmployee>();
            this.removeEmployee = A.Fake<IRemoveEmployee>();
        }

        [TestMethod()]
        public async Task GetTest()
        {
            EmployeeDependency employeeDependency = new(getAllEmployee, getEmployeeById, addNewEmployee, updateEmployee, removeEmployee);
            var result = await employeeDependency.Get();

            Assertion(result);
        }

        [TestMethod()]
        public async Task GetTest1()
        {
            EmployeeDependency employeeDependency = new(getAllEmployee, getEmployeeById, addNewEmployee, updateEmployee, removeEmployee);
            var result = await employeeDependency.Get(1);

            Assertion(result);
        }

        [TestMethod()]
        public async Task PostTest()
        {
            EmployeeDependency employeeDependency = new(getAllEmployee, getEmployeeById, addNewEmployee, updateEmployee, removeEmployee);
            Employees employees = A.Dummy<Employees>();
            var result = await employeeDependency.Post(employees);

            Assertion(result);
        }

        [TestMethod()]
        public async Task PutTest()
        {
            EmployeeDependency employeeDependency = new(getAllEmployee, getEmployeeById, addNewEmployee, updateEmployee, removeEmployee);
            Employees employees = A.Dummy<Employees>();
            var result = await employeeDependency.Put(employees);

            Assertion(result);
        }

        [TestMethod()]
        public async Task DeleteTest()
        {
            EmployeeDependency employeeDependency = new(getAllEmployee, getEmployeeById, addNewEmployee, updateEmployee, removeEmployee);
            Employees employees = A.Dummy<Employees>();
            var result = await employeeDependency.Delete(employees);

            Assertion(result);
        }

        private static void Assertion(List<Employees> resultModel)
        {
            resultModel.Should().NotBeNull();
        }
    }
}