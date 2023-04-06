using System.Data;

namespace aspnetcorewebapisqlclient.Data.Database
{
    public interface IDbConnectionFactory
    {
        IDbConnection Create();
    }
}
