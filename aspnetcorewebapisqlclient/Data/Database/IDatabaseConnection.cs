using System.Data;

namespace aspnetcorewebapisqlclient.Data.Database
{
    public interface IDatabaseConnection
    {
        IDbConnection Create();
    }
}
