global using aspnetcorewebapisqlclient.Business;
global using aspnetcorewebapisqlclient.Business.Interfaces;
global using aspnetcorewebapisqlclient.Data.Database;
global using aspnetcorewebapisqlclient.Data.Service;
global using aspnetcorewebapisqlclient.Models.Data;

using System.Diagnostics.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();


var conn = builder.Configuration.GetSection("ConnectionStrings");

ConnectionStrings connectionStrings = new()
{
    Database = conn["Database"]!,
    Server = conn["Server"]!,
    Trusted_Connection = conn["Trusted_Connection"]!,
    TrustServerCertificate = conn["TrustServerCertificate"]!
};

builder.Services.AddSingleton(connectionStrings);

builder.Services.AddScoped<IConnectionStringFactory, ConnectionStringFactory>();
builder.Services.AddScoped<IQuery, Query>();

builder.Services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

builder.Services
    .AddScoped<IGetAllEmployee, GetAllEmployee>()
    .AddScoped<IGetEmployeeById, GetEmployeeById>()
    .AddScoped<IAddNewEmployee, AddNewEmployee>()
    .AddScoped<IUpdateEmployee, UpdateEmployee>()
    .AddScoped<IRemoveEmployee, RemoveEmployee>();

builder.Services.AddHealthChecks();

builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/health");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


[ExcludeFromCodeCoverage]
public static partial class Program { }