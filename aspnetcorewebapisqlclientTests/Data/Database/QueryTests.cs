namespace aspnetcorewebapisqlclient.Data.Database.Tests
{
    [TestClass()]
    public class QueryTests
    {
        [TestMethod()]
        public void SelectAllEmployeesTest()
        {
            Query query = new Query();
            var result = query.SelectAllEmployees();

            result.Should().NotBeEmpty();
        }

        [TestMethod()]
        public void SelectEmployeeByIdTest()
        {
            Query query = new Query();
            var result = query.SelectEmployeeById(1);

            result.Should().NotBeEmpty();
        }

        [TestMethod()]
        public void AddEmployeeTest()
        {
            Query query = new Query();
            var result = query.AddEmployee(new Employees());

            result.Should().NotBeEmpty();
        }

        [TestMethod()]
        public void UpdateEmployeeTest()
        {
            Query query = new Query();
            var result = query.UpdateEmployee(1, new Employees());

            result.Should().NotBeEmpty();
        }

        [TestMethod()]
        public void RemoveEmployeeTest()
        {
            Query query = new Query();
            var result = query.RemoveEmployee(1);

            result.Should().NotBeEmpty();
        }
    }
}