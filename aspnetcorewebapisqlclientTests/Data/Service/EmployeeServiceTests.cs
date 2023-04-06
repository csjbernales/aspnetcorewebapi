using aspnetcorewebapisqlclient.Data.Database;
using aspnetcorewebapisqlclient.Models.Data;

using System.Data.SqlClient;

namespace aspnetcorewebapisqlclient.Data.Service.Tests
{
    [TestClass()]
    [DoNotParallelize]
    public class EmployeeServiceTests
    {
        private IDbConnectionFactory dbConnectionFactory;
        private readonly ConnectionStringFactory connectionStringFactory = new();
        private readonly IQuery query = new Query();
        private ConnectionStrings connectionStrings;

        [TestInitialize]
        public void Setup()
        {
            dbConnectionFactory = A.Fake<IDbConnectionFactory>();
            connectionStrings = new()
            {
                Database = "maindb",
                Server = "laptop-nonps",
                Trusted_Connection = "True",
                TrustServerCertificate = "True"
            };
        }

        [TestMethod()]
        public void A_GetTest()
        {
            //arrange
            string connstring = connectionStringFactory.ConnectionString(connectionStrings);
            SqlConnection connection = new(connstring);

            A.CallTo(() => dbConnectionFactory.Create()).Returns(connection);

            //act
            EmployeeService employeeService = new(dbConnectionFactory, query);
            var result = employeeService.Get();

            //assert
            result.Result.Should().BeOfType<List<Employees>>();
            result.Result.Should().NotBeNull();
            result.Result.Count.Should().BeGreaterThan(0);
        }

        [TestMethod()]
        public void B_GetSingleTest()
        {
            //arrange
            string connstring = connectionStringFactory.ConnectionString(connectionStrings);
            SqlConnection connection = new(connstring);

            A.CallTo(() => dbConnectionFactory.Create()).Returns(connection);

            //act
            EmployeeService employeeService = new(dbConnectionFactory, query);
            var result = employeeService.Get(1);

            //assert
            result.Result.Should().BeOfType<List<Employees>>();
            result.Result.Should().NotBeNull();
            result.Result.Count.Should().BeGreaterThan(0);
        }

        [TestMethod()]
        public void C_PostTest()
        {
            //arrange
            string connstring = connectionStringFactory.ConnectionString(connectionStrings);
            SqlConnection connection = new(connstring);

            A.CallTo(() => dbConnectionFactory.Create()).Returns(connection);

            Employees employee = new()
            {
                Firstname = "test",
                Middlename = "test",
                Lastname = "test"
            };

            //act
            EmployeeService employeeService = new(dbConnectionFactory, query);
            var result = employeeService.Post(employee);

            //assert
            result.Result.Should().BeOfType<List<Employees>>();
            result.Result.Should().NotBeNull();
            result.Result.Count.Should().BeGreaterThan(0);
        }

        [TestMethod()]
        public void D_PutTest()
        {
            //arrange
            string connstring = connectionStringFactory.ConnectionString(connectionStrings);
            SqlConnection connection = new(connstring);

            A.CallTo(() => dbConnectionFactory.Create()).Returns(connection);

            Employees employee = new()
            {
                Firstname = "test",
                Middlename = "test",
                Lastname = "test"
            };

            //act
            EmployeeService employeeService = new(dbConnectionFactory, query);
            var result = employeeService.Put(employee);

            //assert
            result.Result.Should().BeOfType<List<Employees>>();
            result.Result.Should().NotBeNull();
            result.Result.Count.Should().BeGreaterThan(0);
        }

        [TestMethod()]
        public async Task E_PutTest()
        {
            //arrange
            string connstring = connectionStringFactory.ConnectionString(connectionStrings);
            SqlConnection connection = new(connstring);

            A.CallTo(() => dbConnectionFactory.Create()).Returns(connection);

            Employees employee = new()
            {
                Firstname = "demo",
                Middlename = "test",
                Lastname = "test"
            };

            //act
            EmployeeService employeeService = new(dbConnectionFactory, query);
            await employeeService.Put(employee);

            true.Should().BeTrue();
        }

        [TestMethod()]
        public void F_DeleteTest()
        {
            //arrange
            string connstring = connectionStringFactory.ConnectionString(connectionStrings);
            SqlConnection connection = new(connstring);

            A.CallTo(() => dbConnectionFactory.Create()).Returns(connection);

            Employees employee = new()
            {
                Firstname = "test",
                Middlename = "test",
                Lastname = "test"
            };

            //act
            EmployeeService employeeService = new(dbConnectionFactory, query);
            var result = employeeService.Delete(employee);

            //assert
            result.Result.Should().BeOfType<List<Employees>>();
            result.Result.Should().NotBeNull();
            result.Result.Count.Should().BeGreaterThan(0);
        }

        [TestMethod()]
        public void G_DeleteTest()
        {
            //arrange
            string connstring = connectionStringFactory.ConnectionString(connectionStrings);
            SqlConnection connection = new(connstring);

            A.CallTo(() => dbConnectionFactory.Create()).Returns(connection);

            Employees employee = new()
            {
                Firstname = "demo",
                Middlename = "test",
                Lastname = "test"
            };

            //act
            EmployeeService employeeService = new(dbConnectionFactory, query);
            _ = employeeService.Delete(employee);

            true.Should().BeTrue();

        }
    }
}