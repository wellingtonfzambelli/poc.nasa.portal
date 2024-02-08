using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace Poc.Nasa.Portal.Integration.Shared.HttpClientBase;

public sealed class BaseHttpClient : IBaseHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<BaseHttpClient> _logger;

    public BaseHttpClient(HttpClient httpClient, ILogger<BaseHttpClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<HttpResponseMessage> GetAsync
    (
        string requestUri,
        IReadOnlyDictionary<string, string> queryStrings,
        Guid trackId,
        CancellationToken ct
    )
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        var urlFull = $"{_httpClient.BaseAddress}{requestUri}";
        _logger.LogInformation($"trackId: {trackId} - urlFull: {urlFull}");

        HttpResponseMessage responseMessage = null;

        if (queryStrings is null)
            responseMessage = await new ValueTask<HttpResponseMessage>(
            _httpClient.GetAsync(urlFull, HttpCompletionOption.ResponseHeadersRead, ct));
        else
            responseMessage = await new ValueTask<HttpResponseMessage>(
            _httpClient.GetAsync(QueryHelpers.AddQueryString(urlFull, queryStrings), ct));

        if (ct.IsCancellationRequested)
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);

        stopwatch.Stop();
        _logger.LogInformation($"trackId: {trackId} - reponseMessage: {JsonSerializer.Serialize(responseMessage)} - Timing: {stopwatch.Elapsed}");

        return responseMessage;
    }

    public async Task<HttpResponseMessage> GetAsync
    (
        string requestUri,
        IReadOnlyDictionary<string, IEnumerable<string>> headers,
        IReadOnlyDictionary<string, string> queryStrings,
        Guid trackId,
        CancellationToken ct
    )
    {
        foreach (var header in headers)
        {
            if (_httpClient.DefaultRequestHeaders.Contains(header.Key))
                _httpClient.DefaultRequestHeaders.Remove(header.Key);

            _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
        }

        return await GetAsync(requestUri, queryStrings, trackId, ct);
    }
}