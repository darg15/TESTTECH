using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using TechnicalAPI.Repo.User;
using FluentValidation;
using TechnicalAPI.DTO;
using TechnicalAPI.Repo.Movs;
using TechnicalAPI.UoW;
using TechnicalAPI.Connection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using TechnicalAPI.Repo.Payments;
using TechnicalAPI;
using TechnicalAPI.Repo.Transacciones;
using TechnicalAPI.Repo.Estado;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ConnectionDB>();
builder.Services.AddHealthChecks().AddSqlServer(ConnectionDB.ConnectionString!);
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMovsRepository, MovRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IRepositoryTransacciones, RepositoryTransacciones>();
builder.Services.AddScoped<IEstadoRepository, EstadoRepository>(); 
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IValidator<MovDTO>, MovsDTOValidator>();
builder.Services.AddTransient<IValidator<PaymentsDTO>, PaymentsDTOValidator>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
//builder.Services.AddMediatR(typeof(Program));


var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

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
