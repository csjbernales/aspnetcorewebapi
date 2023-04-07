using aspnetcorewebapisqlclient.Models.Business;

using System.Data;

namespace aspnetcorewebapisqlclient.Data.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IQuery query;
        private readonly IDbConnectionFactory dbConnectionFactory;

        public EmployeeService(IDbConnectionFactory dbConnectionFactory, IQuery query)
        {
            this.query = query;
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<List<Employees>> Get()
        {
            List<Employees> employees = new();

            using IDbConnection connection = dbConnectionFactory.Create();
            await connection.OpenAsync();

            IDbCommand command = connection.CreateCommand();
            command.CommandText = query.SelectAllEmployees();
            using IDataReader reader = await command.ExecuteReaderAsync();

            await ReaderAsyc(employees, reader);

            connection.Close();

            return employees;
        }

        public async Task<List<Employees>> Get(int id)
        {
            List<Employees> employees = new();

            using IDbConnection connection = dbConnectionFactory.Create();
            await connection.OpenAsync();

            IDbCommand command = connection.CreateCommand();
            command.CommandText = query.SelectEmployeeById(id);
            using IDataReader reader = await command.ExecuteReaderAsync();

            await ReaderAsyc(employees, reader);

            return employees;
        }

        public async Task<List<Employees>> Post(Employees employee)
        {
            using IDbConnection connection = dbConnectionFactory.Create();
            await connection.OpenAsync();

            IDbCommand command = connection.CreateCommand();
            command.CommandText = query.AddEmployee(employee);
            await command.ExecuteNonQueryAsync();

            connection.Close();

            return await Get();
        }

        public async Task<List<Employees>> Put(Employees employee)
        {
            using IDbConnection connection = dbConnectionFactory.Create();
            await connection.OpenAsync();

            IDbCommand command = connection.CreateCommand();
            command.CommandText = query.UpdateEmployee(employee);
            int affected = await command.ExecuteNonQueryAsync();

            connection.Close();

            return await Get();
        }

        public async Task<List<Employees>> Delete(Employees employee)
        {
            using IDbConnection connection = dbConnectionFactory.Create();
            await connection.OpenAsync();

            IDbCommand command = connection.CreateCommand();
            command.CommandText = query.RemoveEmployee(employee);
            int affected = await command.ExecuteNonQueryAsync();

            connection.Close();

            return await Get();
        }

        private static async Task ReaderAsyc(List<Employees> employees, IDataReader reader)
        {
            do
            {
                while (await reader.ReadAsync())
                {
                    if (!await reader.IsDBNullAsync(0))
                    {
                        employees.Add(new Employees
                        {
                            Firstname = reader["firstname"].ToString()!,
                            Middlename = reader["middlename"].Equals(string.Empty) ? reader["middlename"].ToString()! : "",
                            Lastname = reader["lastname"].ToString()!,
                        });
                    }
                }
            } while (await reader.NextResultAsync());
        }
    }

}