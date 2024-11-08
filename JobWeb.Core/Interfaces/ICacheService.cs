namespace ApiJob.Interfaces;

public interface ICacheService
{
    bool TryGet<T>(string cacheKey, out T value);
    T set<T>(string cacheKey, T value);
    void Remove(string cacheKey);
}
