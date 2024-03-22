using aspnetcorewebapisqlclient.Business;

namespace aspnetcorewebapisqlclientTests.Business
{
    [TestClass()]
    public class UpdateEmployeeTests
    {
        [TestMethod()]
        public void UpdateEmployeeDataTest()
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
            A.CallTo(() => service.Put(A<Employees>.Ignored)).Returns(employeeList);

            //act
            UpdateEmployee pdateEmployee = new(service);
            var rawResult = pdateEmployee.UpdateEmployeeData(employees);
            var result = rawResult.GetAwaiter().GetResult();

            //assert
            A.CallTo(() => service.Put(A<Employees>.Ignored)).MustHaveHappenedOnceExactly();

            result.Should().NotBeNull();
            result.Should().Contain(employees);
            result.Should().HaveCount(1);
        }
    }
}