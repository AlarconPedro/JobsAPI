using ApiJob.Enumerations;
using ApiJob.Interfaces;
using Hangfire;
using JobWeb.Core.Interfaces;
using JobWeb.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace JobWeb.Infra.Data.Services.Data;

public class GenericService<T> : IGenericService<T> where T : class
{
    private readonly static CacheTech cacheTech = CacheTech.Memory;
    private readonly string cacheKey = $"{typeof(T)}";

    private readonly AppDbContext _context;
    private readonly Func<CacheTech, ICacheService> _cacheService;

    public GenericService(AppDbContext context, Func<CacheTech, ICacheService> cacheService)
    {
        _context = context;
        _cacheService = cacheService;
    }

    public async Task<T> GetById(int id) => await _context.Set<T>().FindAsync(id);

    public async Task<IEnumerable<T>> GetAll()
    {
        if (!_cacheService(cacheTech).TryGet(cacheKey, out IReadOnlyList<T> cachedList))
        {
            cachedList = await _context.Set<T>().ToListAsync();
            _cacheService(cacheTech).set(cacheKey, cachedList);
        }
        return cachedList;
    }

    public async Task<T> Add(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        BackgroundJob.Enqueue(() => RefreshCache());
        return entity;
    }
    public async Task Update(T entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
        BackgroundJob.Enqueue(() => RefreshCache());
    }

    public async Task Delete(int id)
    {
        _context.Set<T>().Remove(_context.Set<T>().Find(id));
        await _context.SaveChangesAsync();
        BackgroundJob.Enqueue(() => RefreshCache());
    }

    public async Task RefreshCache()
    {
        _cacheService(cacheTech).Remove(cacheKey);
        var cachedList = await _context.Set<T>().ToListAsync();
        _cacheService(cacheTech).set(cacheKey, cachedList);
    }
}
