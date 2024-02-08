using Microsoft.Extensions.Logging;
using Poc.Nasa.Portal.Integration.Shared.HttpClientBase;

namespace Poc.Nasa.Portal.Integration.NasaPortal;

public sealed class NasaPortalClient : INasaPortalClient
{
    private readonly IBaseHttpClient _baseHttpClient;
    private readonly ILogger<NasaPortalClient> _logger;
    private readonly string _apiKey;

    public NasaPortalClient
    (
        IBaseHttpClient baseHttpClient,
        ILogger<NasaPortalClient> logger,
        string apiKey
    )
    {
        _logger = logger;
        _baseHttpClient = baseHttpClient;
        _apiKey = apiKey;
    }

    public async Task<GetPictureOfTheDayResponseDto> GetPictureOfTheDayAsync(
        Guid trackId, CancellationToken ct)
    {
        string requestUri = "planetary/apod";

        try
        {
            var queryStrings = new Dictionary<string, string>()
            {
                {
                    "api_key", _apiKey
                }
            };

            var responseMessage = await _baseHttpClient.GetAsync
            (
                requestUri,
                queryStrings,
                trackId,
                ct
            );

            var jsonResponse = await responseMessage.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"trackId: {trackId}");
        }

        return null;
    }
}