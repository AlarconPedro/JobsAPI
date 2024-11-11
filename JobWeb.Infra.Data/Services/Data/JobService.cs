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
    public JobService(AppDbContext context, Func<CacheTech, ICacheService> cacheService) : base(context, cacheService)
    {
        _congelamento = context.Set<TbCongelamento>();
    }
}
