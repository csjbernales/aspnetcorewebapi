using aspnetcorewebapisqlclient.Models;

using System.Data.SqlClient;

namespace aspnetcorewebapisqlclient.Service
{
    public class EmployeeService : IEmployeeService
    {
        private const string connectionString = "Server=laptop-nonps;Database=maindb;Trusted_Connection=True;TrustServerCertificate=true;";

        public async Task<List<Employees>> Get()
        {
            List<Employees> employees = new();
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();
                using SqlCommand cmd = new();
                cmd.Connection = conn;
                cmd.CommandText = "select * from employees";

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
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();
                using SqlCommand cmd = new();
                cmd.Connection = conn;
                cmd.CommandText = $"select * from employees where id = {id}";

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

        public async Task<List<Employees>> Put(int id, Employees employee)
        {
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();
                using SqlCommand cmd = new();
                cmd.Connection = conn;
                cmd.CommandText = $"update employees set firstname = '{employee.Firstname}', middlename = '{employee.Middlename}', lastname= '{employee.Lastname}' where id = {id}";

                await cmd.ExecuteNonQueryAsync();
                conn.Close();
            }

            return await Get();
        }

        public async Task<List<Employees>> Post(Employees employee)
        {
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();
                using SqlCommand cmd = new();
                cmd.Connection = conn;
                cmd.CommandText = $"insert into employees (firstname, middlename, lastname) values ('{employee.Firstname}', '{employee.Middlename}', '{employee.Lastname}');";

                await cmd.ExecuteNonQueryAsync();
                conn.Close();
            }

            return await Get();
        }

        public async Task<List<Employees>> Delete(int id)
        {
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();
                using SqlCommand cmd = new();
                cmd.Connection = conn;
                cmd.CommandText = $"delete from employees where id = {id}";

                await cmd.ExecuteNonQueryAsync();
                conn.Close();
            }

            return await Get();
        }
    }
}