using BuisnessLayerServices;
using DAL.Implementations;
using DAL.Interfaces;
using Repositories;
using RepositoryInterfaces;
using ServiceInterfaces;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

// Add services to the container.

builder.Services.AddSingleton<IScansService, ScansService>();
builder.Services.AddSingleton<IScansRepository, ScansEFRepository>();
builder.Services.AddSingleton<IResourcesRepository, ResourcesRepository>();
builder.Services.AddSingleton<IScansDAL, ScansDAL>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();



app.MapControllers();
//app.MapControllerRoute(
//    name: "scans",
//    pattern: "{controller=scans}/{action=get }/{id?}");

app.Run();
