using aspnetcorewebapisqlclient.Models;

using Microsoft.AspNetCore.Mvc;

using System.Data.SqlClient;

namespace aspnetcorewebapisqlclient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(ILogger<EmployeesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetEmployees")]
        public async Task<List<Employees>> Get()
        {
            string connectionString = "Server=laptop-nonps;Database=maindb;Trusted_Connection=True;TrustServerCertificate=true;";
            List<Employees> employees = new List<Employees>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from employees";

                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    while (reader.Read())
                    {
                        employees.Add(new Employees
                        {
                            Id = (int)reader["id"],
                            Firstname = reader["firstname"].ToString()!,
                            Middlename = reader["middlename"] is not null ? reader["middlename"].ToString()! : "",
                            Lastname = reader["lastname"].ToString()!,
                        });
                    }
                    conn.Close();
                }
            }

            return employees;
        }
    }
}