using ApiJob.Configuration;
using Hangfire;
using JobWeb.Core.Interfaces.Services;
using JobWeb.Infra.Data.Repositories;
using JobWeb.Infra.Data.Services.Data;
using JobWeb.Infra.Data.Services.Entities;
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

////////////////////////////////////////////Inserir Chaves Genêricas////////////////////////////////////
app.MapGet("/InserirChaves", ([FromServices] JobService job) => job.InserirChavesGenericas());

////////////////////////////////////////////Ações Congelamento//////////////////////////////////////////
app.MapGet("/Descongelar/{cngCodigo:int}", ([FromServices] JobService job, int cngCodigo) => job.LiberarChaves(cngCodigo));
app.MapGet("/Congelar/{cngCodigo:int}", ([FromServices] JobService job, int cngCodigo) => job.CongelarChaves(cngCodigo));
app.MapGet("/Inativar/{cngCodigo:int}", ([FromServices] JobService job, int cngCodigo) => job.InativarCongelamento(cngCodigo));
app.MapGet("/Ativar/{cngCodigo:int}", ([FromServices] JobService job, int cngCodigo) => job.AtivarCongelamento(cngCodigo));

////////////////////////////////////////////Ações Produtos//////////////////////////////////////////////
//GET ALL
app.MapGet("/Produtos", ([FromServices] ProdutosService<TbProduto> produto) => produto.GetAll());
app.MapGet("/ProdutosCliente", ([FromServices] ProdutosService<TbProdutoCliente> produto) => produto.GetAll());
app.MapGet("/ChavesProdutos", ([FromServices] ProdutosService<TbProdutoChave> produto) => produto.GetAll());

//GET BY ID
app.MapGet("/Produtos/{id:int}", ([FromServices] ProdutosService<TbProduto> produto, int id) => produto.GetById(id));
app.MapGet("/ProdutosCliente/{id:int}", ([FromServices] ProdutosService<TbProdutoCliente> produto, int id) => produto.GetById(id));
app.MapGet("/ChavesProdutos/{id:int}", ([FromServices] ProdutosService<TbProdutoChave> produto, int id) => produto.GetById(id));

//POST
app.MapPost("/Produtos", ([FromServices] ProdutosService<TbProduto> produto, [FromBody] TbProduto prod) => produto.Add(prod));
app.MapPost("/ProdutosCliente", ([FromServices] ProdutosService<TbProdutoCliente> produto, [FromBody] TbProdutoCliente prod) => produto.Add(prod));
app.MapPost("/ChavesProdutos", ([FromServices] ProdutosService<TbProdutoChave> produto, [FromBody] TbProdutoChave prod) => produto.Add(prod));

//PUT
app.MapPut("/Produtos", ([FromServices] ProdutosService<TbProduto> produto, [FromBody] TbProduto prod) => produto.Update(prod));
app.MapPut("/ProdutosCliente", ([FromServices] ProdutosService<TbProdutoCliente> produto, [FromBody] TbProdutoCliente prod) => produto.Update(prod));
app.MapPut("/ChavesProdutos", ([FromServices] ProdutosService<TbProdutoChave> produto, [FromBody] TbProdutoChave prod) => produto.Update(prod));

//DELETE
app.MapDelete("/Produtos", ([FromServices] ProdutosService<TbProduto> produto, [FromBody] TbProduto prod) => produto.Delete(prod.ProCodigo));
app.MapDelete("/ProdutosCliente", ([FromServices] ProdutosService<TbProdutoCliente> produto, [FromBody] TbProdutoCliente prod) => produto.Delete(prod.ProcliCodigo));
app.MapDelete("/ChavesProdutos", ([FromServices] ProdutosService<TbProdutoChave> produto, [FromBody] TbProdutoChave prod) => produto.Delete(prod.ChaCodigo));

//app.MapControllers();

app.Run();
