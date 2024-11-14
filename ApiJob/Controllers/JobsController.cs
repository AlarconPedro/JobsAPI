using JobWeb.Core.Interfaces.Services.Entities;
using JobWeb.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using JobWeb.Core.Interfaces.Services.Data;

namespace ApiJob.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobsController : ControllerBase
{
    private readonly IJobService _jobService;
    private readonly IProdutoService<TbProduto> _produtoService;
    private readonly IProdutoService<TbProdutoCliente> _produtoClienteService;
    private readonly IProdutoService<TbProdutoChave> _produtoChaveService;

    public JobsController(
        IJobService jobService, 
        IProdutoService<TbProduto> produtoService,
        IProdutoService<TbProdutoCliente> produtoClienteService,
        IProdutoService<TbProdutoChave> produtoChaveService
        ) 
    {
        this._jobService = jobService;
        this._produtoService = produtoService;
        this._produtoClienteService = produtoClienteService;
        this._produtoChaveService = produtoChaveService;
    }

    //Controle
    [HttpGet("Devedores")]
    public async Task<ActionResult> VerificaDevedores() => Ok(await _jobService.VerificaDevedores());

    [HttpGet("Congelados")]
    public async Task<ActionResult> VerificaCongelados() => Ok(await _jobService.VerificaCongelados());

    [HttpGet("InserirChaves")]
    public async Task<ActionResult> InserirChaves() => Ok(await _jobService.InserirChavesGenericas());

    //Ações Congelamento
    [HttpGet("Descongelar/{cngCodigo:int}")]
    public Task LiberarChaves(int cngCodigo) => _jobService.LiberarChaves(cngCodigo);

    [HttpGet("Congelar/{cngCodigo:int}")]
    public Task CongelarChaves(int cngCodigo) => _jobService.CongelarChaves(cngCodigo);

    [HttpGet("Inativar/{cngCodigo:int}")]
    public Task InativarCongelamento(int cngCodigo) => _jobService.InativarCongelamento(cngCodigo);

    [HttpGet("Ativar/{cngCodigo:int}")]
    public Task AtivarCongelamento(int cngCodigo) => _jobService.AtivarCongelamento(cngCodigo);

    //Ações Produtos
    //GET
    [HttpGet("Produtos")]
    public async Task<ActionResult<IEnumerable<TbProduto>>> GetProdutos()
    {
        var produtos = await _produtoService.GetAll();
        if (produtos != null)
            return Ok(produtos);
        return BadRequest();
    } 

    [HttpGet("ProdutosCliente")]
    public async Task<ActionResult> GetProdutosCliente() => Ok(await _produtoClienteService.GetAll());

    [HttpGet("ProdutosChave")]
    public async Task<ActionResult> GetProdutosChave() => Ok(await _produtoChaveService.GetAll());

    //GET BY ID
    [HttpGet("Produtos/{id:int}")]
    public async Task<ActionResult> GetProduto(int id) => Ok(await _produtoService.GetById(id));

    [HttpGet("ProdutosCliente/{id:int}")]
    public async Task<ActionResult> GetProdutoCliente(int id) => Ok(await _produtoClienteService.GetById(id));

    [HttpGet("ProdutosChave/{id:int}")]
    public async Task<ActionResult> GetProdutoChave(int id) => Ok(await _produtoChaveService.GetById(id));

    //POST
    [HttpPost("Produtos")]
    public async Task<ActionResult> AddProduto([FromBody] TbProduto prod) => Ok(await _produtoService.Add(prod));

    [HttpPost("ProdutosCliente")]
    public async Task<ActionResult> AddProdutoCliente([FromBody] TbProdutoCliente prod) => Ok(await _produtoClienteService.Add(prod));

    [HttpPost("ProdutosChave")]
    public async Task<ActionResult> AddProdutoChave([FromBody] TbProdutoChave prod) => Ok(await _produtoChaveService.Add(prod));

    //PUT
    [HttpPut("Produtos")]
    public async Task<ActionResult> UpdateProduto([FromBody] TbProduto prod) => Ok( _produtoService.Update(prod));

    [HttpPut("ProdutosCliente")]
    public async Task<ActionResult> UpdateProdutoCliente([FromBody] TbProdutoCliente prod) => Ok(_produtoClienteService.Update(prod));

    [HttpPut("ProdutosChave")]
    public async Task<ActionResult> UpdateProdutoChave([FromBody] TbProdutoChave prod) => Ok(_produtoChaveService.Update(prod));

    //DELETE
    [HttpDelete("Produtos")]
    public async Task<ActionResult> DeleteProduto([FromBody] TbProduto prod) => Ok(_produtoService.Delete(prod.ProCodigo));

    [HttpDelete("ProdutosCliente")]
    public async Task<ActionResult> DeleteProdutoCliente([FromBody] TbProdutoCliente prod) => Ok(_produtoClienteService.Delete(prod.ProcliCodigo));

    [HttpDelete("ProdutosChave")]
    public async Task<ActionResult> DeleteProdutoChave([FromBody] TbProdutoChave prod) => Ok(_produtoChaveService.Delete(prod.ChaCodigo));
}
