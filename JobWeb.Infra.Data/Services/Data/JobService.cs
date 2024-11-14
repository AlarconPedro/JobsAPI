using ApiJob.Enumerations;
using ApiJob.Interfaces;
using JobWeb.Core.Interfaces.Services.Data;
using JobWeb.Infra.Data.Context;
using JobWeb.Infra.Data.Repositories;

namespace JobWeb.Infra.Data.Services.Data;

public class JobService : CongelamentoService<TbCongelamento>, IJobService
{
    public JobService(AppDbContext context, Func<CacheTech, ICacheService> cacheService) : base(context, cacheService)
    {
    }
}
