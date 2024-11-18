using ApiJob.Enumerations;
using ApiJob.Interfaces;
using JobWeb.Core.Interfaces.Services.Data;
using JobWeb.Infra.Data.Context;
using JobWeb.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobWeb.Infra.Data.Services.Data;

public class JobService : CongelamentoService<TbCongelamento>, IJobService
{
    private readonly DbSet<TbProdutoChave> _produtoChave;
    private readonly DbSet<TbProdutoCliente> _produtoCliente;

    private readonly AppDbContext _context;

    public JobService(AppDbContext context, Func<CacheTech, ICacheService> cacheService) : base(context, cacheService)
    {
        _produtoChave = context.Set<TbProdutoChave>();
        _produtoCliente = context.Set<TbProdutoCliente>();

        _context = context;
    }

    public async Task<int> InserirChavesGenericas()
    {
        var produtos = await _produtoCliente
        .Where(pc => (pc.PesCodigoNavigation.PesStatus.Equals("C") && pc.PesCodigoNavigation.PesCliente.Equals("S"))
            && !pc.TbProdutoChaves.Any())
        .ToListAsync();
        foreach (var produto in produtos)
        {
            _produtoChave.Add(new TbProdutoChave
            {
                ChaAtivo = true,
                ChaCodigo = _produtoChave.Max(pc => pc.ChaCodigo + 1),
                ChaKey = "GENÉRICA",
                ChaObersvacao = "Chave adicionada automáticamente para funcionar o novo modo de validação do sistema",
                ProcliCodigo = produto.ProcliCodigo,
            });
            await _context.SaveChangesAsync();
        }
        return produtos.Count;
    }
}
