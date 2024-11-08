﻿using ApiJob.Enumerations;
using ApiJob.Interfaces;
using Hangfire;
using Hangfire.MemoryStorage;
using JobWeb.Core.Interfaces;
using JobWeb.Core.Interfaces.Services;
using JobWeb.Infra.Data.Context;
using JobWeb.Infra.Data.Repositories;
using JobWeb.Infra.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobWeb.Infra.IoC;

public static class DI
{
    public static IServiceCollection AddInfrastructureApi(this IServiceCollection services, 
        IConfiguration configuration)
    {
        string connectionString = "DataBaseConnection";

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString(connectionString), 
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped(typeof(ICongelamentoRespository<>), typeof(CongelamentoRepository<>));
        services.AddScoped<IJobRepository, JobService>();
        
        //services.AddScoped(typeof(IJobRepository<>), typeof(JobService<>));

        services.AddMemoryCache();
        services.AddTransient<MemoryCacheService>();

        services.AddTransient<Func<CacheTech, ICacheService>>(serviceProvider => key =>
        {
            switch (key)
            {
                case CacheTech.Memory:
                    return serviceProvider.GetService<MemoryCacheService>();
                //case CacheTech.Redis:
                //return serviceProvider.GetService<RedisCacheService>();
                default:
                    return serviceProvider.GetService<MemoryCacheService>();
            }
        });

        //services.AddHangfire(x => x.UseSqlServerStorage(configuration.GetConnectionString(connectionString)));
        services.AddHangfire(config => config.UseMemoryStorage());
        GlobalConfiguration.Configuration.UseMemoryStorage();
        services.AddHangfireServer();
        
        services.AddAuthorization();
        services.AddHangfireServer();

        return services;
    }
}
