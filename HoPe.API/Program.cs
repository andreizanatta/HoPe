using FluentValidation;
using FluentValidation.AspNetCore;
using HoPe.API.Filters;
using HoPe.Application.Commands.CreateReservation;
using HoPe.Application.Services.Implementations;
using HoPe.Application.Services.Interfaces;
using HoPe.Application.Validators;
using HoPe.Core.Repositories;
using HoPe.Core.Service;
using HoPe.Infrastructure.Auth;
using HoPe.Infrastructure.Persistence;
using HoPe.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt => opt.Filters.Add(typeof(ValidationFilter)));
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateReservationCommandValidator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("HoPeCs");
builder.Services.AddDbContext<HoPeDbContext>(op => op.UseSqlServer(connectionString));

builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateReservationCommand).Assembly));
//iniciando microsft azure
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
