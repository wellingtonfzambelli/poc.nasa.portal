using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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

    public async Task<GetPictureOfTheDayResponseClientDto> GetPictureOfTheDayAsync(
        Guid trackId, CancellationToken ct)
    {
        string enpoint = "planetary/apod";

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
                enpoint,
                queryStrings,
                trackId,
                ct
            );

            var jsonResponse = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessage.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<GetPictureOfTheDayResponseClientDto>(jsonResponse);

            return ExtractBadRequest(jsonResponse, trackId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"trackId: {trackId}");
            throw ex;
        }
    }

    private GetPictureOfTheDayResponseClientDto ExtractBadRequest(string jsonResponse, Guid trackId)
    {
        _logger.LogWarning(jsonResponse, $"trackId: {trackId}");

        var responseErro = JsonConvert.DeserializeObject<NasaBadRequestClientDto>(jsonResponse);

        var response = new GetPictureOfTheDayResponseClientDto();
        response.SetError(responseErro);

        return response;
    }
}