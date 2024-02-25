namespace Poc.Nasa.Portal.Infrastructure.Cache;

public interface ICacheService
{
    Task SetAsync(string key, string value, CancellationToken ct);
    Task InsertAsync<T>(T type, CancellationToken ct) where T : class;
}