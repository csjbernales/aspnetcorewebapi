using aspnetcorewebapisqlclient.Models.Business;

namespace aspnetcorewebapisqlclient.Business.Interfaces
{
    public interface IUpdateEmployee
    {
        Task<List<Employees>> UpdateEmployeeData(Employees employees);
    }
}