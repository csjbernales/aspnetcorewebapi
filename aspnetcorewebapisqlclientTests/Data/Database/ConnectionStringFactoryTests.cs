using aspnetcorewebapisqlclient.Models.Data;

namespace aspnetcorewebapisqlclient.Data.Database.Tests
{
    [TestClass()]
    public class ConnectionStringFactoryTests
    {
        [TestMethod()]
        public void ConnectionStringTest()
        {
            //arrange
            ConnectionStrings connectionStrings = new()
            {
                Database = "test",
                Server = "test",
                Trusted_Connection = "test",
                TrustServerCertificate = "test"
            };

            //act
            ConnectionStringFactory connectionStringFactory = new();
            var result = connectionStringFactory.ConnectionString(connectionStrings);

            //assert
            result.Should().NotBeEmpty();
        }
        [TestMethod()]
        public void ConnectionStringTest_Fail()
        {
            //arrange
            ConnectionStrings? connectionStrings = null;

            //act
            ConnectionStringFactory connectionStringFactory = new();
            var result = connectionStringFactory.ConnectionString(connectionStrings!);

            //assert
            result.Should().BeEmpty();
        }
    }
}