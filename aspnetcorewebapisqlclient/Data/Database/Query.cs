namespace aspnetcorewebapisqlclient.Data.Database
{
    public abstract class Query
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

        public string UpdateEmployee(Employees employee)
        {
            return $"update employees set firstname = '{employee.Firstname}', middlename = '{employee.Middlename}', lastname= '{employee.Lastname}' where firstname = '{employee.Firstname}'";
        }

        public string RemoveEmployee(Employees employee)
        {
            return $"delete from employees where firstname = '{employee.Firstname}'";
        }
    }
}
