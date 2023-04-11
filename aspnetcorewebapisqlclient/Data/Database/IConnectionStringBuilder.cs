namespace aspnetcorewebapisqlclient.Data.Database
{
    public interface IConnectionStringBuilder
    {
        string ConnectionString(ConnectionStrings Options);
    }
}