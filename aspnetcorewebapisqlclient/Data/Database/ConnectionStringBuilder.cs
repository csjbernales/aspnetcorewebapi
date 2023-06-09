﻿namespace aspnetcorewebapisqlclient.Data.Database
{
    public class ConnectionStringBuilder : IConnectionStringBuilder
    {

        public string ConnectionString(ConnectionStrings Options)
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
