using aspnetcorewebapisqlclient.Business;
using aspnetcorewebapisqlclient.Business.Interfaces;
using aspnetcorewebapisqlclient.Data.Database;
using aspnetcorewebapisqlclient.Data.Service;
using aspnetcorewebapisqlclient.Models.Data;

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

builder.Services
    .AddScoped<IGetAllEmployee, GetAllEmployee>()
    .AddScoped<IGetEmployeeById, GetEmployeeById>()
    .AddScoped<IAddNewEmployee, AddNewEmployee>()
    .AddScoped<IUpdateEmployee, UpdateEmployee>()
    .AddScoped<IRemoveEmployee, RemoveEmployee>();

builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
