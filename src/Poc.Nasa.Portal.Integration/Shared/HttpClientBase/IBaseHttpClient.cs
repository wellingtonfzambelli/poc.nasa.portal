namespace Poc.Nasa.Portal.Integration.Shared.HttpClientBase;

public interface IBaseHttpClient
{
    Task<HttpResponseMessage> GetAsync
    (
        string endpoint,
        IReadOnlyDictionary<string, string> queryStrings,
        Guid trackId,
        CancellationToken ct
    );

    Task<HttpResponseMessage> GetAsync
    (
        string endpoint,
        IReadOnlyDictionary<string, IEnumerable<string>> headers,
        IReadOnlyDictionary<string, string> queryStrings,
        Guid trackId,
        CancellationToken ct
    );
}