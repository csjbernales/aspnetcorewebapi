using aspnetcorewebapisqlclient.Models.Data;

namespace aspnetcorewebapisqlclient.Data.Database
{
    public static class ConnectionStringFactory
    {

        public static string ConnectionString(ConnectionStrings Options)
        {
            if (Options is not null)
            {
                string server = Options.Server;
                string database = Options.Database;
                string trustedConnection = Options.Trusted_Connection;
                string trustServerCertificate = Options.TrustServerCertificate;

                return $"Server={server};" +
                    $"Database={database};" +
                    $"Trusted_Connection={trustedConnection};" +
                    $"TrustServerCertificate={trustServerCertificate};";
            }

            return string.Empty;
        }
    }
}
