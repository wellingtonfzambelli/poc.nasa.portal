﻿using MediatR;
using Microsoft.Extensions.Logging;
using Poc.Nasa.Portal.Integration.NasaPortal;

namespace Poc.Nasa.Portal.App.Nasa.AstronomyPicture;

public sealed class AstronomyPictureOfTheDayHandler : IRequestHandler<AstronomyPictureOfTheDayRequestHandlerDto, AstronomyPictureOfTheDayResponseDto>
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

    public async Task<AstronomyPictureOfTheDayResponseDto> Handle(
        AstronomyPictureOfTheDayRequestHandlerDto request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("info AstronomyPictureOfTheDayHandler");

        var response = new AstronomyPictureOfTheDayResponseDto();

        if (await _validator.ValidateAsync(request.RequestDto, cancellationToken)
            is var validation && !validation.IsValid)
            return null;

        if (await _nasaPortalClient.GetPictureOfTheDayAsync(request.TrackId, cancellationToken)
            is var nasaResponse && nasaResponse is null)
            return null;

        return response;
    }
}