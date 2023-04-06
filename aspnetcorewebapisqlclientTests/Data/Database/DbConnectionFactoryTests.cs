using aspnetcorewebapisqlclient.Models.Data;

using System.Data.SqlClient;

namespace aspnetcorewebapisqlclient.Data.Database.Tests
{
    [TestClass()]
    public class DbConnectionFactoryTests
    {

        [TestMethod()]
        public void CreateTest()
        {
            IConnectionStringFactory connectionStringFactory = A.Fake<IConnectionStringFactory>();
            ConnectionStrings connectionStrings = new ConnectionStrings()
            {
                Database = "test",
                Server = "test",
                Trusted_Connection = "True",
                TrustServerCertificate = "True"
            };

            DbConnectionFactory dbConnectionFactory = new(connectionStringFactory, connectionStrings); ;
            var result = dbConnectionFactory.Create();

            result.Should().NotBeNull();
            result.Should().BeOfType<SqlConnection>();
        }
    }
}