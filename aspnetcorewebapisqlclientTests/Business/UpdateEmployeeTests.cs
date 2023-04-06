namespace aspnetcorewebapisqlclient.Business.Tests
{
    [TestClass()]
    public class UpdateEmployeeTests
    {
        [TestMethod()]
        public void UpdateEmployeeDataTest()
        {
            //arrange
            int id = 1;
            Employees employees = new()
            {
                Firstname = string.Empty,
                Middlename = string.Empty,
                Lastname = string.Empty
            };
            IEmployeeService service = A.Fake<IEmployeeService>();
            List<Employees> employeeList = new() { employees };
            A.CallTo(() => service.Put(A<int>.Ignored, A<Employees>.Ignored)).Returns(employeeList);

            //act
            UpdateEmployee pdateEmployee = new(service);
            var rawResult = pdateEmployee.UpdateEmployeeData(id, employees);
            var result = rawResult.GetAwaiter().GetResult();

            //assert
            A.CallTo(() => service.Put(A<int>.Ignored, A<Employees>.Ignored)).MustHaveHappenedOnceExactly();

            result.Should().NotBeNull();
            result.Should().Contain(employees);
            result.Should().HaveCount(1);
        }
    }
}