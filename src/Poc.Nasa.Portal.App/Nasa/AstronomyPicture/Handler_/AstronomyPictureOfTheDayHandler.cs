using Microsoft.Extensions.Logging;

namespace Poc.Nasa.Portal.App.Nasa.AstronomyPicture;

public sealed class AstronomyPictureOfTheDayHandler
{
    private readonly AstronomyPictureOfTheDayValidator _validator;
    private readonly ILogger<AstronomyPictureOfTheDayHandler> _logger;

    public AstronomyPictureOfTheDayHandler
    (
        AstronomyPictureOfTheDayValidator validator,
        ILogger<AstronomyPictureOfTheDayHandler> logger
    )
    {
        _validator = validator;
        _logger = logger;
    }

    public async Task<AstronomyPictureOfTheDayResponseDto> HandleAsync(AstronomyPictureOfTheDayRequestDto request, CancellationToken ct)
    {
        _logger.LogInformation("info AstronomyPictureOfTheDayHandler");

        var response = new AstronomyPictureOfTheDayResponseDto();

        if (await _validator.ValidateAsync(request, ct)
            is var validation && !validation.IsValid)
            return null;

        return response;
    }
}