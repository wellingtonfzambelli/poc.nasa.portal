namespace Poc.Nasa.Portal.Infrastructure.Cache;

public interface ICacheService
{
    Task InsertAsync<T>(T type) where T : class;
}