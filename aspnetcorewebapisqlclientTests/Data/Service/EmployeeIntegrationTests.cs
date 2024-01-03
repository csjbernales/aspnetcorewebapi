using aspnetcorewebapisqlclient.Data.Database;
using aspnetcorewebapisqlclient.Models.Data;

using System.Data.SqlClient;

namespace aspnetcorewebapisqlclientTests.Data.Service
{
    [TestClass()]
    [DoNotParallelize]
    public class EmployeeIntegrationTests
    {
        private IDatabaseConnection dbConnectionFactory;
        private readonly ConnectionStringBuilder connectionStringFactory = new();
        private ConnectionStrings connectionStrings;
        string connstring;
        SqlConnection connection;

        [TestInitialize]
        public void Setup()
        {
            dbConnectionFactory = A.Fake<IDatabaseConnection>();
            connectionStrings = new()
            {
                Database = "maindb",
                Server = "TUF-FX504",
                Trusted_Connection = "True",
                TrustServerCertificate = "True"
            };
            connstring = connectionStringFactory.ConnectionString(connectionStrings);
            connection = new(connstring);
        }

        [TestMethod()]
        public void A_GetTest()
        {
            //arrange
            A.CallTo(() => dbConnectionFactory.Create()).Returns(connection);

            //act
            EmployeeService employeeService = new(dbConnectionFactory);
            var result = employeeService.Get();

            //assert
            Assertions(result);
        }

        [TestMethod()]
        public void B_GetSingleTest()
        {
            //arrange
            A.CallTo(() => dbConnectionFactory.Create()).Returns(connection);

            //act
            EmployeeService employeeService = new(dbConnectionFactory);
            var result = employeeService.Get(5);

            //assert
            Assertions(result);
        }

        [TestMethod()]
        public void C_PostTest()
        {
            //arrange
            A.CallTo(() => dbConnectionFactory.Create()).Returns(connection);

            Employees employee = new()
            {
                Firstname = "test",
                Middlename = "test",
                Lastname = "test"
            };

            //act
            EmployeeService employeeService = new(dbConnectionFactory);
            var result = employeeService.Post(employee);

            //assert
            Assertions(result);
        }

        [TestMethod()]
        public void D_PutTest()
        {
            //arrange
            A.CallTo(() => dbConnectionFactory.Create()).Returns(connection);

            Employees employee = new()
            {
                Firstname = "test",
                Middlename = "test",
                Lastname = "test"
            };

            //act
            EmployeeService employeeService = new(dbConnectionFactory);
            var result = employeeService.Put(employee);

            //assert
            Assertions(result);
        }

        [TestMethod()]
        public async Task E_PutTest()
        {
            //arrange
            A.CallTo(() => dbConnectionFactory.Create()).Returns(connection);

            Employees employee = new()
            {
                Firstname = "demo",
                Middlename = "test",
                Lastname = "test"
            };

            //act
            EmployeeService employeeService = new(dbConnectionFactory);
            await employeeService.Put(employee);

            true.Should().BeTrue();
        }

        [TestMethod()]
        public void F_DeleteTest()
        {
            //arrange
            A.CallTo(() => dbConnectionFactory.Create()).Returns(connection);

            Employees employee = new()
            {
                Firstname = "test",
                Middlename = "test",
                Lastname = "test"
            };

            //act
            EmployeeService employeeService = new(dbConnectionFactory);
            var result = employeeService.Delete(employee);

            //assert
            Assertions(result);
        }

        [TestMethod()]
        public void G_DeleteTest()
        {
            //arrange
            A.CallTo(() => dbConnectionFactory.Create()).Returns(connection);

            Employees employee = new()
            {
                Firstname = "demo",
                Middlename = "test",
                Lastname = "test"
            };

            //act
            EmployeeService employeeService = new(dbConnectionFactory);
            _ = employeeService.Delete(employee);

            true.Should().BeTrue();
        }

        private static void Assertions(Task<List<Employees>> result)
        {
            result.Result.Should().BeOfType<List<Employees>>();
            result.Result.Should().NotBeNull();
            result.Result.Count.Should().BeGreaterThan(0);
        }
    }
}