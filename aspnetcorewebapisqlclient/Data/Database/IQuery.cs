using aspnetcorewebapisqlclient.Models.Business;

namespace aspnetcorewebapisqlclient.Data.Database
{
    public interface IQuery
    {
        string AddEmployee(Employees employee);
        string SelectAllEmployees();
        string SelectEmployeeById(int id);
        string UpdateEmployee(Employees employee);
        string RemoveEmployee(Employees employee);
    }
}