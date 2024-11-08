using ApiJob.Configuration;
using Hangfire;
using JobWeb.Core.Interfaces.Services;
using JobWeb.Infra.Data.Repositories;
using JobWeb.Infra.IoC;
using Microsoft.AspNetCore.Mvc;

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

//Jobs

//Jobs Diários
RecurringJob.AddOrUpdate("Verifica Devedores", (JobService job) => job.VerificaDevedores(), Cron.Minutely);
RecurringJob.AddOrUpdate("Envia Avisos", (JobService job) => job.EnviaAvisos(), Cron.Minutely);

//Jobs Horários
//Verifica se quem está congelado/á congelar já pagou
RecurringJob.AddOrUpdate("Verifica Congelados", (JobService job) => job.VerificaCongelados(), Cron.Hourly);


//Routes
//Controle
app.MapGet("/Devedores", ([FromServices] JobService job) => job.VerificaDevedores());
app.MapGet("/Congelados", ([FromServices] JobService job) => job.VerificaCongelados());


//Ações
app.MapGet("/Descongelar/{cngCodigo:int}", ([FromServices] JobService job, int cngCodigo) => job.LiberarChaves(cngCodigo));
app.MapGet("/Congelar/{cngCodigo:int}", ([FromServices] JobService job, int cngCodigo) => job.CongelarChaves(cngCodigo));
app.MapGet("/Inativar/{cngCodigo:int}", ([FromServices] JobService job, int cngCodigo) => job.InativarCongelamento(cngCodigo));
app.MapGet("/Ativar/{cngCodigo:int}", ([FromServices] JobService job, int cngCodigo) => job.AtivarCongelamento(cngCodigo));

//app.MapControllers();

app.Run();
