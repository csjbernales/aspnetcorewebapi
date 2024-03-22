using System.Data;
using System.Data.SqlClient;

namespace aspnetcorewebapisqlclient.Data.Database
{
    public class DatabaseConnection(IConnectionStringBuilder connectionStringFactory, ConnectionStrings connectionStrings) : IDatabaseConnection
    {
        public IDbConnection Create()
        {
            SqlConnection connection = new(connectionStringFactory.ConnectionString(connectionStrings));

            return connection;
        }
    }
}
