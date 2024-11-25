using ApiJob.Configuration;
using Hangfire;
using JobWeb.Core.Interfaces.Services.Data;
using JobWeb.Core.Interfaces.Services.Entities;
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
RecurringJob.AddOrUpdate("Verifica Devedores", (IJobService job) => job.VerificaDevedores(), Cron.Minutely);
RecurringJob.AddOrUpdate("Envia Avisos", (IJobService job) => job.EnviaAvisos(), Cron.Minutely);

//Jobs Horários
//Verifica se quem está congelado/á congelar já pagou
RecurringJob.AddOrUpdate("Verifica Congelados", (IJobService job) => job.VerificaCongelados(), Cron.Hourly);

//Routes
//Controle
app.MapGet("/Devedores", (IJobService job) => job.VerificaDevedores());
app.MapGet("/Congelados", (IJobService job) => job.VerificaCongelados());

////////////////////////////////////////////Inserir Chaves Genêricas////////////////////////////////////
app.MapGet("/InserirChaves", (IJobService job) => job.InserirChavesGenericas());

//////////////////////////////////////////Ações Congelamento//////////////////////////////////////////
app.MapGet("/Descongelar/{cngCodigo:int}", (IJobService job, int cngCodigo) => job.LiberarChaves(cngCodigo));
app.MapGet("/Congelar/{cngCodigo:int}", (IJobService job, int cngCodigo) => job.CongelarChaves(cngCodigo));
app.MapGet("/Inativar/{cngCodigo:int}", (IJobService job, int cngCodigo) => job.InativarCongelamento(cngCodigo));
app.MapGet("/Ativar/{cngCodigo:int}", (IJobService job, int cngCodigo) => job.AtivarCongelamento(cngCodigo));

//////////////////////////////////////////////Ações Produtos//////////////////////////////////////////////
//GET ALL
app.MapGet("/Produtos", (IProdutoService produto) => produto.GetAll());
app.MapGet("/ProdutosCliente", (IProdutoService produto) => produto.GetAll());
app.MapGet("/ChavesProdutos", (IProdutoService produto) => produto.GetAll());

//GET BY ID
app.MapGet("/Produtos/{id:int}", (IProdutoService produto, int id) => produto.GetById(id));
app.MapGet("/ProdutosCliente/{id:int}", (IProdutoClienteService produto, int id) => produto.GetById(id));
app.MapGet("/ChavesProdutos/{id:int}", (IProdutoChaveService produto, int id) => produto.GetById(id));

//POST
app.MapPost("/Produtos", (IProdutoService produto, [FromBody] TbProduto prod) => produto.Add(prod));
app.MapPost("/ProdutosCliente", (IProdutoClienteService produto, [FromBody] TbProdutoCliente prod) => produto.Add(prod));
app.MapPost("/ChavesProdutos", (IProdutoChaveService produto, [FromBody] TbProdutoChave prod) => produto.Add(prod));

//PUT
app.MapPut("/Produtos", (IProdutoService produto, [FromBody] TbProduto prod) => produto.Update(prod));
app.MapPut("/ProdutosCliente", (IProdutoClienteService produto, [FromBody] TbProdutoCliente prod) => produto.Update(prod));
app.MapPut("/ChavesProdutos", (IProdutoChaveService produto, [FromBody] TbProdutoChave prod) => produto.Update(prod));

//DELETE
app.MapDelete("/Produtos", (IProdutoService produto, [FromBody] TbProduto prod) => produto.Delete(prod.ProCodigo));
app.MapDelete("/ProdutosCliente", (IProdutoClienteService produto, [FromBody] TbProdutoCliente prod) => produto.Delete(prod.ProcliCodigo));
app.MapDelete("/ChavesProdutos", (IProdutoChaveService produto, [FromBody] TbProdutoChave prod) => produto.Delete(prod.ChaCodigo));

//app.MapControllers();

app.Run();
