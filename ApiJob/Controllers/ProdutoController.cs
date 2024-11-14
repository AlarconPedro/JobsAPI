using JobWeb.Core.Interfaces.Services.Entities;
using JobWeb.Infra.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiJob.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService<TbProduto> _produtoService;
    private readonly IProdutoService<TbProdutoCliente> _produtoClienteService;
    private readonly IProdutoService<TbProdutoChave> _produtoChaveService;

    public ProdutoController(
        IProdutoService<TbProduto> produtoService,
        IProdutoService<TbProdutoCliente> produtoClienteService,
        IProdutoService<TbProdutoChave> produtoChaveService)
    {
        this._produtoService = produtoService;
        this._produtoClienteService = produtoClienteService;
        this._produtoChaveService = produtoChaveService;
    }

    //GET
    [HttpGet("Produtos")]
    public async Task<ActionResult<IEnumerable<TbProduto>>> GetProdutos() => Ok(await _produtoService.GetAll());

    [HttpGet("ProdutosCliente")]
    public async Task<ActionResult> GetProdutosCliente()
    {
        var produtos = await _produtoClienteService.GetAll();
        if (produtos != null)
            return Ok(produtos);

        return NotFound("Nenhum Produto Encontrado");
    }
}
