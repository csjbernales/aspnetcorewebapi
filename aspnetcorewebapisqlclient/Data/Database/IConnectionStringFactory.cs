using aspnetcorewebapisqlclient.Models.Data;

namespace aspnetcorewebapisqlclient.Data.Database
{
    public interface IConnectionStringFactory
    {
        string ConnectionString(ConnectionStrings Options);
    }
}