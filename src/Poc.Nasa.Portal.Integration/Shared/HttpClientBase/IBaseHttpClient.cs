namespace Poc.Nasa.Portal.Integration.Shared.HttpClientBase;

public interface IBaseHttpClient
{
    Task<HttpResponseMessage> GetAsync(Guid correlationId, string requestUri, CancellationToken ct);
    Task<HttpResponseMessage> GetAsync(Guid correlationId, string requestUri, IReadOnlyDictionary<string, IEnumerable<string>> headers, CancellationToken ct);
}