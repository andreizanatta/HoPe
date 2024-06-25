using HoPe.Application.Services.Implementations;
using HoPe.Application.Services.Interfaces;
using HoPe.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("HoPeCs");
builder.Services.AddDbContext<HoPeDbContext>(op => op.UseSqlServer(connectionString));

builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IPetService, PetService>();

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
