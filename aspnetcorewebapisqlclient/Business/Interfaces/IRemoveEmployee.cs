using aspnetcorewebapisqlclient.Models.Business;

namespace aspnetcorewebapisqlclient.Business.Interfaces
{
    public interface IRemoveEmployee
    {
        Task<List<Employees>> RemoveEmployeeData(Employees employees);
    }
}