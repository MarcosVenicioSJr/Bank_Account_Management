using MoneyMover.API;
using MoneyMover.API.Interfaces;
using MoneyMover.API.Repository;
using MoneyMover.API.Service;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Database
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddTransient(_ => new MySqlConnection(connectionString));
builder.Services.AddScoped<IDbSession, DbSession>();

//Injection Dependency
builder.Services.AddTransient<IMoneyTransferService, MoneyService>();
builder.Services.AddTransient<IRepository, MoneyRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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