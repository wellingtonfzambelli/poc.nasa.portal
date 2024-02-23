namespace Poc.Nasa.Portal.Infrastructure.Cache;

public interface ICacheService
{
    Task SetAsync(string key, string value, CancellationToken ct);
    Task<string> GetAsync(string key, CancellationToken ct);
}