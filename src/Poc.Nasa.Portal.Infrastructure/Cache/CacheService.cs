using Microsoft.Extensions.Caching.Distributed;

namespace Poc.Nasa.Portal.Infrastructure.Cache;

public sealed class CacheService : ICacheService
{
    private readonly IDistributedCache _cache;
    private readonly DistributedCacheEntryOptions _options;

    public CacheService(IDistributedCache cache)
    {
        _cache = cache;
        _options = new DistributedCacheEntryOptions
        {

        };
    }

    public async Task<string> GetAsync(string key, CancellationToken ct) =>
        await _cache.GetStringAsync(key, ct);

    public async Task SetAsync(string key, string value, CancellationToken ct) =>
        await _cache.SetStringAsync(key, value, _options, ct);
}