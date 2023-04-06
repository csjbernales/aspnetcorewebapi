namespace aspnetcorewebapisqlclient.Business.Tests
{
    [TestClass()]
    public class GetAllEmployeeTests
    {

        [TestMethod()]
        public void GetAllEmployeesTest()
        {
            //arrange
            Employees employees = new()
            {
                Firstname = string.Empty,
                Middlename = string.Empty,
                Lastname = string.Empty
            };
            IEmployeeService service = A.Fake<IEmployeeService>();
            List<Employees> employeeList = new() { employees };
            A.CallTo(() => service.Get()).Returns(employeeList);

            //act
            GetAllEmployee getAllEmployee = new(service);
            var rawResult = getAllEmployee.GetAllEmployees();
            var result = rawResult.GetAwaiter().GetResult();

            //assert
            A.CallTo(() => service.Get()).MustHaveHappenedOnceExactly();

            result.Should().NotBeNull();
            result.Should().Contain(employees);
            result.Should().HaveCount(1);
        }
    }

}