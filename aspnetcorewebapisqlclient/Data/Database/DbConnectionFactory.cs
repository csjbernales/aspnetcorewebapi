using System.Data;
using System.Data.SqlClient;

namespace aspnetcorewebapisqlclient.Data.Database
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConnectionStringFactory connectionStringFactory;
        private readonly ConnectionStrings connectionStrings;

        public DbConnectionFactory(IConnectionStringFactory connectionStringFactory, ConnectionStrings connectionStrings)
        {
            this.connectionStringFactory = connectionStringFactory;
            this.connectionStrings = connectionStrings;
        }
        public IDbConnection Create()
        {

            SqlConnection connection = new(connectionStringFactory.ConnectionString(connectionStrings));

            return connection;
        }
    }
}
