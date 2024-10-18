using BuisnessLayerServiceInterfaces;
using BuisnessLayerServices;
using CommonInfra;
using CypagoApp.ExceptionHandling;
using CypagoApp.Mappers.Implementations;
using CypagoApp.Mappers.Interfaces;
using DAL.Contexts;
using DAL.Implementations;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Mappers;
using Repositories.Mappers.Impl;
using Repositories.Mappers.Interfaces;
using RepositoryInterfaces;
using ServiceInterfaces;
void ConfigureDb(IServiceCollection services, IConfiguration config)
{
    services.AddEntityFrameworkSqlServer();
    services.AddDbContextPool<ScansContext>(options =>
    {
        options.UseSqlServer(config.GetSection(Constants.CONNECTION_STRING)?.Value);
    });

    services.AddDbContextPool<ResourcesContext>(options =>
    {
        options.UseSqlServer(config.GetSection(Constants.CONNECTION_STRING)?.Value);
    });

}

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole(c =>
{
    c.TimestampFormat = "[HH:mm:ss] ";
});

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var MyAllowSpecificOrigins = "_MyAllowSubdomainPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://example.com",
                                              "http://www.contoso.com", "http://localhost:3000");
                      });
});

// Add services to the container.

ConfigureDb(builder.Services, configuration);



//builder.Services.AddDbContext<ScansContext>();

builder.Services.AddScoped<IScansService, ScansService>();
builder.Services.AddScoped<IResourcesService, ResourcesService>();

builder.Services.AddScoped<IScansRepository, ScansRepository>();
builder.Services.AddScoped<IResourcesRepository, ResourcesRepository>();

builder.Services.AddScoped<IScansDAL, ScansDAL>();
builder.Services.AddScoped<IResourcesDAL, ResourcesDAL>();

builder.Services.AddSingleton<IScanMapper, ScanMapper>();
builder.Services.AddSingleton<IResourceMapper, ResourceMapper>();
builder.Services.AddSingleton<IResourceRequestMapper, ResourceRequestMapper>();
builder.Services.AddSingleton<IScanRequestMapper, ScanRequestMapper>();
builder.Services.AddSingleton<IParamsMapper, ParamsMapper>();
builder.Services.AddSingleton<IQueryParamsMapper, QueryParamsMapper>();

builder.Services.AddControllers();



var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionHandler>();
app.Run();
