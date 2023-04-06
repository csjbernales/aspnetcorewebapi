using aspnetcorewebapisqlclient.Data.Database;
using aspnetcorewebapisqlclient.Models.Business;
using aspnetcorewebapisqlclient.Models.Data;

using System.Data.SqlClient;

namespace aspnetcorewebapisqlclient.Data.Service
{
    public class EmployeeService : Query, IEmployeeService
    {
        public readonly ConnectionStrings Options;

        public EmployeeService(ConnectionStrings options)
        {
            Options = options;
        }

        public async Task<List<Employees>> Get()
        {
            List<Employees> employees = new();
            using (SqlConnection conn = new(ConnectionStringFactory.ConnectionString(Options)))
            {
                conn.Open();
                using SqlCommand cmd = new();
                cmd.Connection = conn;
                cmd.CommandText = SelectAllEmployees();

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
            using (SqlConnection conn = new(ConnectionStringFactory.ConnectionString(Options)))
            {
                conn.Open();
                using SqlCommand cmd = new();
                cmd.Connection = conn;
                cmd.CommandText = SelectEmployeeById(id);

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
            using (SqlConnection conn = new(ConnectionStringFactory.ConnectionString(Options)))
            {
                conn.Open();
                using SqlCommand cmd = new();
                cmd.Connection = conn;
                cmd.CommandText = AddEmployee(employee);

                await cmd.ExecuteNonQueryAsync();
                conn.Close();
            }

            return await Get();
        }

        public async Task<List<Employees>> Put(int id, Employees employee)
        {
            using (SqlConnection conn = new(ConnectionStringFactory.ConnectionString(Options)))
            {
                conn.Open();
                using SqlCommand cmd = new();
                cmd.Connection = conn;
                cmd.CommandText = UpdateEmployee(id, employee);

                await cmd.ExecuteNonQueryAsync();
                conn.Close();
            }

            return await Get();
        }

        public async Task<List<Employees>> Delete(int id)
        {
            using (SqlConnection conn = new(ConnectionStringFactory.ConnectionString(Options)))
            {
                conn.Open();
                using SqlCommand cmd = new();
                cmd.Connection = conn;
                cmd.CommandText = RemoveEmployee(id);

                await cmd.ExecuteNonQueryAsync();
                conn.Close();
            }

            return await Get();
        }
    }
}