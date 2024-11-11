using ApiJob.Enumerations;
using ApiJob.Interfaces;
using JobWeb.Core.Interfaces.Services.Entities;
using JobWeb.Infra.Data.Context;
using JobWeb.Infra.Data.Repositories;
using JobWeb.Infra.Data.Services.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobWeb.Infra.Data.Services.Entities;

public class ProdutosService<T> : GenericService<T>, IProdutoService<T> where T : class
{
    public ProdutosService(AppDbContext context, Func<CacheTech, ICacheService> cacheService) : base(context, cacheService)
    {
    }
}
