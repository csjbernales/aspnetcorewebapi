using System.Data;

namespace aspnetcorewebapisqlclient.Data.Service
{
    public class EmployeeService : Query, IEmployeeService
    {
        private readonly IDatabaseConnection dbConnectionFactory;

        public EmployeeService(IDatabaseConnection dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<List<Employees>> Get()
        {
            List<Employees> employees = new();

            IDbConnection connection = dbConnectionFactory.Create();
            await connection.OpenAsync();

            IDbCommand command = connection.CreateCommand();
            command.CommandText = SelectAllEmployees();
            IDataReader reader = command.ExecuteReader();

            Reader(employees, reader);

            connection.Close();

            return employees;
        }

        public async Task<List<Employees>> Get(int id)
        {
            List<Employees> employees = new();

            IDbConnection connection = dbConnectionFactory.Create();
            await connection.OpenAsync();

            IDbCommand command = connection.CreateCommand();
            command.CommandText = SelectEmployeeById(id);
            IDataReader reader = command.ExecuteReader();

            Reader(employees, reader);

            return employees;
        }

        public async Task<List<Employees>> Post(Employees employee)
        {
            IDbConnection connection = dbConnectionFactory.Create();
            await connection.OpenAsync();

            IDbCommand command = connection.CreateCommand();
            command.CommandText = AddEmployee(employee);
            command.ExecuteNonQuery();

            connection.Close();

            return await Get();
        }

        public async Task<List<Employees>> Put(Employees employee)
        {
            IDbConnection connection = dbConnectionFactory.Create();
            await connection.OpenAsync();

            IDbCommand command = connection.CreateCommand();
            command.CommandText = UpdateEmployee(employee);
            command.ExecuteNonQuery();

            connection.Close();

            return await Get();
        }

        public async Task<List<Employees>> Delete(Employees employee)
        {
            IDbConnection connection = dbConnectionFactory.Create();
            await connection.OpenAsync();

            IDbCommand command = connection.CreateCommand();
            command.CommandText = RemoveEmployee(employee);
            command.ExecuteNonQuery();

            connection.Close();

            return await Get();
        }

        private static void Reader(List<Employees> employees, IDataReader reader)
        {
            do
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        employees.Add(new Employees
                        {
                            Firstname = reader["firstname"].ToString(),
                            Middlename = reader["middlename"].ToString(),
                            Lastname = reader["lastname"].ToString()!,
                        });
                    }
                }
            } while (reader.NextResult());
        }
    }
}