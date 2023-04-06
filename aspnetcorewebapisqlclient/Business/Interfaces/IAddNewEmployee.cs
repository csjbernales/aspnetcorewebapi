using aspnetcorewebapisqlclient.Models.Business;

namespace aspnetcorewebapisqlclient.Business.Interfaces
{
    public interface IAddNewEmployee
    {
        Task<List<Employees>> AddEmployee(Employees employees);
    }
}