using ApiJob.Enumerations;
using ApiJob.Interfaces;
using ApiJob.Servicos;
using JobWeb.Core.Interfaces;
using JobWeb.Core.Interfaces.Services;
using JobWeb.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace JobWeb.Infra.Data.Repositories;

public class JobService : CongelamentoRepository<TbCongelamento>, IJobRepository
{
    private readonly DbSet<TbCongelamento> _congelamento;
    public JobService(AppDbContext context, Func<CacheTech, ICacheService> cacheService) : base(context, cacheService)
    {
        _congelamento = context.Set<TbCongelamento>();
    }
}
