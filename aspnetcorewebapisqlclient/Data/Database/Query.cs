using aspnetcorewebapisqlclient.Models.Business;

namespace aspnetcorewebapisqlclient.Data.Database
{
    public class Query : IQuery
    {

        public string SelectAllEmployees()
        {
            return $"select * from employees {""}";
        }

        public string SelectEmployeeById(int id)
        {
            return $"select * from employees where id = {id}";
        }

        public string AddEmployee(Employees employee)
        {
            return $"insert into employees (firstname, middlename, lastname) values ('{employee.Firstname}', '{employee.Middlename}', '{employee.Lastname}');";
        }

        public string UpdateEmployee(int id, Employees employee)
        {
            return $"update employees set firstname = '{employee.Firstname}', middlename = '{employee.Middlename}', lastname= '{employee.Lastname}' where id = {id}";
        }

        public string RemoveEmployee(int id)
        {
            return $"delete from employees where id = {id}";
        }
    }
}
