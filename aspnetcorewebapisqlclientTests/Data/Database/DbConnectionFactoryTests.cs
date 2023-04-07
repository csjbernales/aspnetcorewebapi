using aspnetcorewebapisqlclient.Data.Database;
using aspnetcorewebapisqlclient.Models.Data;

using System.Data.SqlClient;

namespace aspnetcorewebapisqlclientTests.Data.Database
{
    [TestClass()]
    public class DbConnectionFactoryTests
    {

        [TestMethod()]
        public void CreateTest()
        {
            IConnectionStringFactory connectionStringFactory = A.Fake<IConnectionStringFactory>();
            ConnectionStrings connectionStrings = new()
            {
                Database = "test",
                Server = "test",
                Trusted_Connection = "True",
                TrustServerCertificate = "True"
            };

            DbConnectionFactory dbConnectionFactory = new(connectionStringFactory, connectionStrings);
            var result = dbConnectionFactory.Create();

            result.Should().NotBeNull();
            result.Should().BeOfType<SqlConnection>();
        }
    }
}