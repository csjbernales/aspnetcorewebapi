using System.Data;
using System.Data.SqlClient;

namespace aspnetcorewebapisqlclient.Data.Database
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private readonly IConnectionStringBuilder connectionStringFactory;
        private readonly ConnectionStrings connectionStrings;

        public DatabaseConnection(IConnectionStringBuilder connectionStringFactory, ConnectionStrings connectionStrings)
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
