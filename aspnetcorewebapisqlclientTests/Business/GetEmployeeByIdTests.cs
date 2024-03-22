using aspnetcorewebapisqlclient.Business;

namespace aspnetcorewebapisqlclientTests.Business
{
    [TestClass()]
    public class GetEmployeeByIdTests
    {

        [TestMethod()]
        public void GetEmployeeTest()
        {
            //arrange
            Employees employees = new()
            {
                Firstname = string.Empty,
                Middlename = string.Empty,
                Lastname = string.Empty
            };
            IEmployeeService service = A.Fake<IEmployeeService>();
            List<Employees> employeeList = [employees];
            A.CallTo(() => service.Get(1)).Returns(employeeList);

            //act
            GetEmployeeById getEmployeeById = new(service);
            var rawResult = getEmployeeById.GetEmployee(1);
            var result = rawResult.GetAwaiter().GetResult();

            //assert
            A.CallTo(() => service.Get(1)).MustHaveHappenedOnceExactly();

            result.Should().NotBeNull();
            result.Should().Contain(employees);
            result.Should().HaveCount(1);
        }
    }
}