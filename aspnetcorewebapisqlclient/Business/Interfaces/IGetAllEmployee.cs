namespace aspnetcorewebapisqlclient.Business.Interfaces
{
    public interface IGetAllEmployee
    {
        Task<List<Employees>> GetAllEmployees();
    }
}