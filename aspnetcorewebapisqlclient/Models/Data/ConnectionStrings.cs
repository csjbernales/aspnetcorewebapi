namespace aspnetcorewebapisqlclient.Models.Data
{
    public class ConnectionStrings
    {
        public string Server { get; set; } = string.Empty;
        public string Database { get; set; } = string.Empty;
        public string Trusted_Connection { get; set; } = string.Empty;
        public string TrustServerCertificate { get; set; } = string.Empty;
    }
}
