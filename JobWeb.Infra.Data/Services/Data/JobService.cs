using ApiJob.Enumerations;
using ApiJob.Interfaces;
using ApiJob.Servicos;
using JobWeb.Core.Interfaces;
using JobWeb.Core.Interfaces.Services;
using JobWeb.Infra.Data.Context;
using JobWeb.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace JobWeb.Infra.Data.Services.Data;

public class JobService : CongelamentoService<TbCongelamento>, IJobService
{
    private readonly DbSet<TbCongelamento> _congelamento;
    private readonly DbSet<TbProdutoChave> _produtoChave;
    private readonly DbSet<TbProdutoCliente> _produtoCliente;
    public JobService(AppDbContext context, Func<CacheTech, ICacheService> cacheService) : base(context, cacheService)
    {
        _congelamento = context.Set<TbCongelamento>();
        _produtoChave = context.Set<TbProdutoChave>();
        _produtoCliente = context.Set<TbProdutoCliente>();
    }

    public async Task InserirChavesGenericas() { 
        var listaProdutosSemChave = await _produtoCliente.Where(pc => !pc.TbProdutoChaves.Any()).ToListAsync();
        foreach (var produto in listaProdutosSemChave)
        {
            var chave = new TbProdutoChave
            {
                ChaAtivo = true,
                ChaCodigo = _produtoChave.Max(pc => pc.ChaCodigo) + 1,
                ChaKey = "GENÉRICA",
                ChaObersvacao = "Chave adicionada automaticamente para funcionamento do novo modo de validação",
                ProcliCodigo = produto.ProcliCodigo,
            };
            await _produtoChave.AddAsync(chave);
        }
    }
}
