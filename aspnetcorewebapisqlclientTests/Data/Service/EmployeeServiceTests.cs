using aspnetcorewebapisqlclient.Data.Database;

using System.Data;

namespace aspnetcorewebapisqlclientTests.Data.Service
{
    [TestClass()]
    [DoNotParallelize]
    public class EmployeeServiceTests
    {
        private IDatabaseConnection dbConnectionFactory;

        [TestInitialize]
        public void Setup()
        {
            dbConnectionFactory = A.Fake<IDatabaseConnection>();
        }

        [TestMethod()]
        public void A_GetTest()
        {
            //arrange
            var conn = A.Dummy<IDbConnection>();
            A.CallTo(() => conn.State).Returns(ConnectionState.Open);

            IDbCommand command = A.Dummy<IDbCommand>();
            A.CallTo(() => conn.CreateCommand()).Returns(command);
            command.CommandText = "select query";

            IDataReader reader = A.Dummy<IDataReader>();
            A.CallTo(() => reader.FieldCount).Returns(3);
            A.CallTo(() => reader.Read()).Returns(true);
            A.CallTo(() => reader["firstname"]).Returns("firstname");
            A.CallTo(() => reader["middlename"]).Returns("middlename");
            A.CallTo(() => reader["lastname"]).Returns("lastname");

            A.CallTo(() => reader.GetFieldType(0)).Returns(typeof(string));
            A.CallTo(() => reader.GetFieldType(1)).Returns(typeof(string));
            A.CallTo(() => reader.GetFieldType(2)).Returns(typeof(string));

            A.CallTo(() => command.ExecuteReader()).Returns(reader);
            A.CallTo(() => reader.Read()).ReturnsNextFromSequence(true, false);
            A.CallTo(() => reader.IsDBNull(0)).ReturnsNextFromSequence(false, false, false, true);
            A.CallTo(() => reader.NextResult()).ReturnsNextFromSequence(false);
            A.CallTo(() => dbConnectionFactory.Create()).Returns(conn);

            ///act
            EmployeeService employeeService = new(dbConnectionFactory);
            var response = employeeService.Get();

            //assert
            Assertions(response);
        }

        [TestMethod()]
        public void B_GetSingleTest()
        {
            //arrange
            var conn = A.Dummy<IDbConnection>();
            A.CallTo(() => conn.State).Returns(ConnectionState.Open);

            IDbCommand command = A.Dummy<IDbCommand>();
            A.CallTo(() => conn.CreateCommand()).Returns(command);
            command.CommandText = "select query";

            IDataReader reader = A.Dummy<IDataReader>();
            A.CallTo(() => reader.FieldCount).Returns(3);
            A.CallTo(() => reader.Read()).Returns(true);
            A.CallTo(() => reader["firstname"]).Returns("firstname");
            A.CallTo(() => reader["middlename"]).Returns("middlename");
            A.CallTo(() => reader["lastname"]).Returns("lastname");

            A.CallTo(() => reader.GetFieldType(0)).Returns(typeof(string));
            A.CallTo(() => reader.GetFieldType(1)).Returns(typeof(string));
            A.CallTo(() => reader.GetFieldType(2)).Returns(typeof(string));

            A.CallTo(() => command.ExecuteReader()).Returns(reader);
            A.CallTo(() => reader.Read()).ReturnsNextFromSequence(true, false);
            A.CallTo(() => reader.IsDBNull(0)).ReturnsNextFromSequence(false, false, false, true);
            A.CallTo(() => reader.NextResult()).ReturnsNextFromSequence(false);
            A.CallTo(() => dbConnectionFactory.Create()).Returns(conn);

            ///act
            EmployeeService employeeService = new(dbConnectionFactory);
            var response = employeeService.Get(1);

            //assert
            Assertions(response);
        }

        [TestMethod()]
        public void C_PostTest()
        {
            //arrange
            Employees employees =
                new()
                {
                    Firstname = "firstname",
                    Middlename = "middlename",
                    Lastname = "lastname"
                };

            var conn = A.Dummy<IDbConnection>();
            A.CallTo(() => conn.State).Returns(ConnectionState.Open);

            IDbCommand command = A.Dummy<IDbCommand>();
            A.CallTo(() => conn.CreateCommand()).Returns(command);
            command.CommandText = "select query";

            IDataReader reader = A.Dummy<IDataReader>();
            A.CallTo(() => reader.FieldCount).Returns(3);
            A.CallTo(() => reader.Read()).Returns(true);
            A.CallTo(() => reader["firstname"]).Returns("firstname");
            A.CallTo(() => reader["middlename"]).Returns("middlename");
            A.CallTo(() => reader["lastname"]).Returns("lastname");

            A.CallTo(() => reader.GetFieldType(0)).Returns(typeof(string));
            A.CallTo(() => reader.GetFieldType(1)).Returns(typeof(string));
            A.CallTo(() => reader.GetFieldType(2)).Returns(typeof(string));
            A.CallTo(() => reader.Read()).ReturnsNextFromSequence(true, false);
            A.CallTo(() => reader.IsDBNull(0)).ReturnsNextFromSequence(false, false, false, true);
            A.CallTo(() => reader.NextResult()).ReturnsNextFromSequence(false);

            A.CallTo(() => command.ExecuteReader()).Returns(reader);

            A.CallTo(() => command.ExecuteNonQuery()).Returns(1);
            A.CallTo(() => dbConnectionFactory.Create()).Returns(conn);

            ///act
            EmployeeService employeeService = new(dbConnectionFactory);
            var response = employeeService.Post(employees);

            //assert
            Assertions(response);
        }

        [TestMethod()]
        public void D_PutTest()
        {
            //arrange
            Employees employees =
                new()
                {
                    Firstname = "firstname",
                    Middlename = "middlename",
                    Lastname = "lastname"
                };

            var conn = A.Dummy<IDbConnection>();
            A.CallTo(() => conn.State).Returns(ConnectionState.Open);

            IDbCommand command = A.Dummy<IDbCommand>();
            A.CallTo(() => conn.CreateCommand()).Returns(command);
            command.CommandText = "select query";

            IDataReader reader = A.Dummy<IDataReader>();
            A.CallTo(() => reader.FieldCount).Returns(3);
            A.CallTo(() => reader.Read()).Returns(true);
            A.CallTo(() => reader["firstname"]).Returns("firstname");
            A.CallTo(() => reader["middlename"]).Returns("middlename");
            A.CallTo(() => reader["lastname"]).Returns("lastname");

            A.CallTo(() => reader.GetFieldType(0)).Returns(typeof(string));
            A.CallTo(() => reader.GetFieldType(1)).Returns(typeof(string));
            A.CallTo(() => reader.GetFieldType(2)).Returns(typeof(string));
            A.CallTo(() => reader.Read()).ReturnsNextFromSequence(true, false);
            A.CallTo(() => reader.IsDBNull(0)).ReturnsNextFromSequence(false, false, false, true);
            A.CallTo(() => reader.NextResult()).ReturnsNextFromSequence(false);

            A.CallTo(() => command.ExecuteReader()).Returns(reader);

            A.CallTo(() => command.ExecuteNonQuery()).Returns(1);
            A.CallTo(() => dbConnectionFactory.Create()).Returns(conn);

            ///act
            EmployeeService employeeService = new(dbConnectionFactory);
            var response = employeeService.Put(employees);

            //assert
            Assertions(response);
        }

        [TestMethod()]
        public void E_DeleteTest()
        {
            //arrange
            Employees employees =
                new()
                {
                    Firstname = "firstname",
                    Middlename = "middlename",
                    Lastname = "lastname"
                };

            var conn = A.Dummy<IDbConnection>();
            A.CallTo(() => conn.State).Returns(ConnectionState.Open);

            IDbCommand command = A.Dummy<IDbCommand>();
            A.CallTo(() => conn.CreateCommand()).Returns(command);
            command.CommandText = "select query";

            IDataReader reader = A.Dummy<IDataReader>();
            A.CallTo(() => reader.FieldCount).Returns(3);
            A.CallTo(() => reader.Read()).Returns(true);
            A.CallTo(() => reader["firstname"]).Returns("firstname");
            A.CallTo(() => reader["middlename"]).Returns("middlename");
            A.CallTo(() => reader["lastname"]).Returns("lastname");

            A.CallTo(() => reader.GetFieldType(0)).Returns(typeof(string));
            A.CallTo(() => reader.GetFieldType(1)).Returns(typeof(string));
            A.CallTo(() => reader.GetFieldType(2)).Returns(typeof(string));
            A.CallTo(() => reader.Read()).ReturnsNextFromSequence(true, false);
            A.CallTo(() => reader.IsDBNull(0)).ReturnsNextFromSequence(false, false, false, true);
            A.CallTo(() => reader.NextResult()).ReturnsNextFromSequence(false);

            A.CallTo(() => command.ExecuteReader()).Returns(reader);

            A.CallTo(() => command.ExecuteNonQuery()).Returns(1);
            A.CallTo(() => dbConnectionFactory.Create()).Returns(conn);

            ///act
            EmployeeService employeeService = new(dbConnectionFactory);
            var response = employeeService.Delete(employees);

            //assert
            Assertions(response);
        }

        private static void Assertions(Task<List<Employees>> result)
        {
            result.Result.Should().BeOfType<List<Employees>>();
            result.Result.Should().NotBeNull();
            result.Result.Count.Should().BeGreaterThan(0);
        }
    }
}