using ApartmentService.Business.InterfaceServices;
using ApartmentService.Business.Services;
using ApartmentService.DataAccess.InterfaceRepositories;
using ApartmentService.DataAccess.Models;
using ApartmentService.DataAccess.Repositories;
using ApartmentService.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WebApi")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Dependency Injection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ISettingRoomService, SettingRoomService>();
builder.Services.AddTransient<IBillingService, BillingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

// global cors policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
