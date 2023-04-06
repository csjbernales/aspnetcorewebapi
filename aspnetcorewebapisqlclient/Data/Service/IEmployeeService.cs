using aspnetcorewebapisqlclient.Models.Business;

namespace aspnetcorewebapisqlclient.Data.Service
{
    public interface IEmployeeService
    {
        Task<List<Employees>> Get();
        Task<List<Employees>> Get(int id);
        Task<List<Employees>> Post(Employees employee);
        Task<List<Employees>> Put(int id, Employees employee);
        Task<List<Employees>> Delete(int id);
    }
}