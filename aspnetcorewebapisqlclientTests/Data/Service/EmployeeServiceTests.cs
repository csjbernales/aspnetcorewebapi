using aspnetcorewebapisqlclient.Data.Database;
using aspnetcorewebapisqlclient.Models.Data;

namespace aspnetcorewebapisqlclient.Data.Service.Tests
{
    [TestClass()]
    public class EmployeeServiceTests
    {

        [TestMethod()]
        public void GetTest()
        {
            IConnectionStringFactory connectionStringFactory = A.Fake<IConnectionStringFactory>();
            IQuery query = new Query();
            ConnectionStrings connectionStrings = new();

            A.CallTo(() => connectionStringFactory.ConnectionString(connectionStrings)).Returns(string.Empty);

            //act
            EmployeeService employeeService = new(connectionStrings, connectionStringFactory, query);
            var result = employeeService.Get();

            //assert
            result.Result.Should().BeOfType<List<Employees>>();
            result.Result.Should().NotBeNull();
        }

        [TestMethod()]
        public void GetTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PostTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PutTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }
    }
}