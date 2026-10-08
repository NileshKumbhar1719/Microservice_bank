using BankEmployee.Model;
using BankEmployee.Repository;
using BankEmployee.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var emp = builder.Configuration.GetConnectionString("defaultstrings");
builder.Services.AddDbContext<DbContextbank>(option =>
{
    option.UseSqlServer(emp);
});

builder.Services.AddScoped<IEmpRepository,EmpRepository>();
builder.Services.AddScoped<IEmpServices,EmpServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
