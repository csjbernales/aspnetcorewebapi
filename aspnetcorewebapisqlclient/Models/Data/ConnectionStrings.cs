namespace aspnetcorewebapisqlclient.Models.Data
{
    public class ConnectionStrings
    {
        public required string Server { get; set; }
        public required string Database { get; set; }
        public required string Trusted_Connection { get; set; }
        public required string TrustServerCertificate { get; set; }
    }
}
