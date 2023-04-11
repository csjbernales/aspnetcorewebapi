namespace aspnetcorewebapisqlclient.Controllers
{
    public interface IEmployeeDependency
    {
        Task<List<Employees>> Get();
        Task<List<Employees>> Get(int id);
        Task<List<Employees>> Post(Employees employees);
        Task<List<Employees>> Put(Employees employees);
        Task<List<Employees>> Delete(Employees employees);
    }
}