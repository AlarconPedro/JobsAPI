using ApiJob.Configuration;
using Hangfire;
using JobWeb.Infra.Data.Repositories;
using JobWeb.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add service AddInfrastruture to the container.
builder.Services.AddInfrastructureApi(builder.Configuration);

builder.Services.Configure<CacheConfiguration>(builder.Configuration.GetSection("CacheConfiguration"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHangfireDashboard("/Jobs");

app.MapGet("/Congelamento", (JobRepository job) => job.GetAll());

//app.MapControllers();

app.Run();
