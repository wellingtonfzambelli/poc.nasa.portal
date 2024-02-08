using Microsoft.Extensions.Logging;
using Poc.Nasa.Portal.Integration.NasaPortal;

namespace Poc.Nasa.Portal.App.Nasa.AstronomyPicture;

public sealed class AstronomyPictureOfTheDayHandler
{
    private readonly AstronomyPictureOfTheDayValidator _validator;
    private readonly INasaPortalClient _nasaPortalClient;
    private readonly ILogger<AstronomyPictureOfTheDayHandler> _logger;

    public AstronomyPictureOfTheDayHandler
    (
        AstronomyPictureOfTheDayValidator validator,
        INasaPortalClient nasaPortalClient,
        ILogger<AstronomyPictureOfTheDayHandler> logger
    )
    {
        _validator = validator;
        _nasaPortalClient = nasaPortalClient;
        _logger = logger;
    }

    public async Task<AstronomyPictureOfTheDayResponseDto> HandleAsync(
        AstronomyPictureOfTheDayRequestDto request, CancellationToken ct)
    {
        _logger.LogInformation("info AstronomyPictureOfTheDayHandler");

        var response = new AstronomyPictureOfTheDayResponseDto();

        if (await _validator.ValidateAsync(request, ct)
            is var validation && !validation.IsValid)
            return null;

        if (await _nasaPortalClient.GetPictureOfTheDayAsync(Guid.NewGuid(), ct)
            is var nasaResponse && nasaResponse is null)
            return null;

        return response;
    }
}