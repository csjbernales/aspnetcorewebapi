using aspnetcorewebapisqlclient.Controllers;
using aspnetcorewebapisqlclient.Middleware;

using System.Diagnostics.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);

var conn = builder.Configuration.GetSection("ConnectionStrings");

ConnectionStrings connectionStrings = new()
{ 
    Database = conn["Database"]!,
    Server = conn["Server"]!,
    Trusted_Connection = conn["Trusted_Connection"]!,
    TrustServerCertificate = conn["TrustServerCertificate"]!
};

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(connectionStrings);

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<IConnectionStringBuilder, ConnectionStringBuilder>();

builder.Services.AddScoped<IDatabaseConnection, DatabaseConnection>();

builder.Services
    .AddScoped<IGetAllEmployee, GetAllEmployee>()
    .AddScoped<IGetEmployeeById, GetEmployeeById>()
    .AddScoped<IAddNewEmployee, AddNewEmployee>()
    .AddScoped<IUpdateEmployee, UpdateEmployee>()
    .AddScoped<IRemoveEmployee, RemoveEmployee>();

builder.Services.AddScoped<IEmployeeDependency, EmployeeDependency>();

builder.Services.AddHealthChecks();

builder.Services.AddApplicationInsightsTelemetry();

builder.Services.AddAuthentication().AddJwtBearer();

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandler>();
app.UseMiddleware<AuthHandler>();

app.MapHealthChecks("/health");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

[ExcludeFromCodeCoverage]
public static partial class Program
{ }