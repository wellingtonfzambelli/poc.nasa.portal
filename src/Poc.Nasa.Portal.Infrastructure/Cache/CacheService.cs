using Redis.OM;

namespace Poc.Nasa.Portal.Infrastructure.Cache;

public sealed class CacheService : ICacheService
{
    private readonly RedisConnectionProvider _provider;

    public CacheService(RedisConnectionProvider provider) =>
        _provider = provider;

    public async Task InsertAsync<T>(T type) where T : class
    {
        var collection = _provider.RedisCollection<T>();
        await collection.InsertAsync(type);
    }
}