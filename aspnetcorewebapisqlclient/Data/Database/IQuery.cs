using aspnetcorewebapisqlclient.Models.Business;

namespace aspnetcorewebapisqlclient.Data.Database
{
    public interface IQuery
    {
        string AddEmployee(Employees employee);
        string SelectAllEmployees();
        string SelectEmployeeById(int id);
        string UpdateEmployee(int id, Employees employee);
        string RemoveEmployee(int id);
    }
}