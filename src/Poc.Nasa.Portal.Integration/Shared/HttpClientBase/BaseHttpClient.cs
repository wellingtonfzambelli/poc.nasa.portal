using System.Diagnostics;
using System.Net;

namespace Poc.Nasa.Portal.Integration.Shared.HttpClientBase;

public sealed class BaseHttpClient : IBaseHttpClient
{
    private readonly HttpClient _httpClient;

    public BaseHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpResponseMessage> GetAsync
    (
        Guid correlationId,
        string requestUri,
        CancellationToken ct
    )
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        var urlFull = $"{_httpClient.BaseAddress}{requestUri}";
        //await LogRequestAsync(correlationId, urlFull);

        var responseMessage = await new ValueTask<HttpResponseMessage>(
            _httpClient.GetAsync(urlFull, HttpCompletionOption.ResponseHeadersRead, ct));

        if (ct.IsCancellationRequested)
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);

        stopwatch.Stop();

        //await LogResponseAsync(correlationId, urlFull, responseMessage, stopwatch.Elapsed);
        return responseMessage;
    }

    public async Task<HttpResponseMessage> GetAsync
    (
        Guid correlationId,
        string requestUri,
        IReadOnlyDictionary<string, IEnumerable<string>> headers,
        CancellationToken ct
    )
    {
        foreach (var header in headers)
        {
            if (_httpClient.DefaultRequestHeaders.Contains(header.Key))
                _httpClient.DefaultRequestHeaders.Remove(header.Key);

            _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
        }

        return await GetAsync(correlationId, requestUri, ct);
    }
}