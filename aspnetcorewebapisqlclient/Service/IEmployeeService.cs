using aspnetcorewebapisqlclient.Models;

namespace aspnetcorewebapisqlclient.Service
{
    public interface IEmployeeService
    {
        Task<List<Employees>> Delete(int id);
        Task<List<Employees>> Get();
        Task<List<Employees>> Get(int id);
        Task<List<Employees>> Post(Employees employee);
        Task<List<Employees>> Put(int id, Employees employee);
    }
}