
using ApiJob.Enumerations;
using ApiJob.Interfaces;
using JobWeb.Core.Interfaces.Services.Entities;
using JobWeb.Infra.Data.Context;
using JobWeb.Infra.Data.Repositories;
using JobWeb.Infra.Data.Services.Data;
using Microsoft.EntityFrameworkCore;
using OmegaCloudAPI.Models.OmegaCloud.Empresa;

namespace JobWeb.Infra.Data.Services.Entities;

public class EmpresaService : GenericService<TbEmpresa>, IEmpresaService
{
    private readonly DbSet<TbEmpresa> _empresa;

    public EmpresaService(AppDbContext context, Func<CacheTech, ICacheService> cacheService) : base(context, cacheService)
    {
        _empresa = context.Set<TbEmpresa>();
    }
    public async Task<IEnumerable<EmpresaDadosBasicos>> GetEmpresasLogin(int codigoPessoa)
    {
        return await _empresa
            .Where(e => e.TbPessoas.Any(p => p.PesCodigo == codigoPessoa))
            .Select(x => new EmpresaDadosBasicos
            {
                EmpCodigo = x.EmpCodigo,
                EmpNome = x.EmpNome,
            }).ToListAsync();
    }

    public async Task<IEnumerable<EmpresaDadosBasicos>> GetEmpresas()
    {
        return await _empresa.Select(x => new EmpresaDadosBasicos
        {
            EmpCodigo = x.EmpCodigo,
            EmpNome = x.EmpNome,
            EmpFone = x.EmpFone,
        }).ToListAsync();
    }
}
