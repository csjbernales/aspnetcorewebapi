using aspnetcorewebapisqlclient.Models.Business;

using System.Data.SqlClient;

namespace aspnetcorewebapisqlclient.Data.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IConnectionStringFactory connectionStringFactory;
        private readonly ConnectionStrings Options;
        private readonly IQuery query;

        public EmployeeService(ConnectionStrings options, IConnectionStringFactory connectionStringFactory, IQuery query)
        {
            this.query = query;
            Options = options;
            this.connectionStringFactory = connectionStringFactory;
        }

        public async Task<List<Employees>> Get()
        {
            List<Employees> employees = new();
            using (SqlConnection conn = new(connectionStringFactory.ConnectionString(Options)))
            {
                conn.Open();
                using SqlCommand cmd = new();
                cmd.Connection = conn;
                cmd.CommandText = query.SelectAllEmployees();

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (reader.Read())
                {
                    employees.Add(new Employees
                    {
                        Firstname = reader["firstname"].ToString()!,
                        Middlename = reader["middlename"] is not null ? reader["middlename"].ToString()! : "",
                        Lastname = reader["lastname"].ToString()!,
                    });
                }
                conn.Close();
            }

            return employees;
        }

        public async Task<List<Employees>> Get(int id)
        {
            List<Employees> employees = new();
            using (SqlConnection conn = new(connectionStringFactory.ConnectionString(Options)))
            {
                conn.Open();
                using SqlCommand cmd = new();
                cmd.Connection = conn;
                cmd.CommandText = query.SelectEmployeeById(id);

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (reader.Read())
                {
                    employees.Add(new Employees
                    {
                        Firstname = reader["firstname"].ToString()!,
                        Middlename = reader["middlename"] is not null ? reader["middlename"].ToString()! : "",
                        Lastname = reader["lastname"].ToString()!,
                    });
                }
                conn.Close();
            }
            return employees;
        }

        public async Task<List<Employees>> Post(Employees employee)
        {
            using (SqlConnection conn = new(connectionStringFactory.ConnectionString(Options)))
            {
                conn.Open();
                using SqlCommand cmd = new();
                cmd.Connection = conn;
                cmd.CommandText = query.AddEmployee(employee);

                await cmd.ExecuteNonQueryAsync();
                conn.Close();
            }

            return await Get();
        }

        public async Task<List<Employees>> Put(int id, Employees employee)
        {
            using (SqlConnection conn = new(connectionStringFactory.ConnectionString(Options)))
            {
                conn.Open();
                using SqlCommand cmd = new();
                cmd.Connection = conn;
                cmd.CommandText = query.UpdateEmployee(id, employee);

                await cmd.ExecuteNonQueryAsync();
                conn.Close();
            }

            return await Get();
        }

        public async Task<List<Employees>> Delete(int id)
        {
            using (SqlConnection conn = new(connectionStringFactory.ConnectionString(Options)))
            {
                conn.Open();
                using SqlCommand cmd = new();
                cmd.Connection = conn;
                cmd.CommandText = query.RemoveEmployee(id);

                await cmd.ExecuteNonQueryAsync();
                conn.Close();
            }

            return await Get();
        }
    }
}