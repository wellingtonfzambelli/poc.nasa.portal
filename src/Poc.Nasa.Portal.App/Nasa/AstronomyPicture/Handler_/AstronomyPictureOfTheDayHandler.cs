﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Poc.Nasa.Portal.App.Shared;
using Poc.Nasa.Portal.Domain.Models.PictureOfTheDayAggregate;
using Poc.Nasa.Portal.Infrastructure.Configurations;
using Poc.Nasa.Portal.Infrastructure.MessageBroker;
using Poc.Nasa.Portal.Infrastructure.UnitOfWork;
using Poc.Nasa.Portal.Integration.NasaPortal;
using System.Text.Json;

namespace Poc.Nasa.Portal.App.Nasa.AstronomyPicture;

public sealed class AstronomyPictureOfTheDayHandler : IRequestHandler<AstronomyPictureOfTheDayRequestHandlerDto, AstronomyPictureOfTheDayResponseDto>
{
    private readonly AstronomyPictureOfTheDayValidator _validator;
    private readonly INasaPortalClient _nasaPortalClient;
    private readonly IMapper _mapper;
    private readonly ILogger<AstronomyPictureOfTheDayHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISetupMessageBroker _setupMessageBroker;
    private readonly IConfiguration _configuration;

    public AstronomyPictureOfTheDayHandler
    (
        AstronomyPictureOfTheDayValidator validator,
        INasaPortalClient nasaPortalClient,
        IMapper mapper,
        ILogger<AstronomyPictureOfTheDayHandler> logger,
        IUnitOfWork unitOfWork,
        ISetupMessageBroker setupMessageBroker,
        IConfiguration configuration
    )
    {
        _validator = validator;
        _nasaPortalClient = nasaPortalClient;
        _mapper = mapper;
        _logger = logger;
        _unitOfWork = unitOfWork;
        _setupMessageBroker = setupMessageBroker;
        _configuration = configuration;
    }

    public async Task<AstronomyPictureOfTheDayResponseDto> Handle(
        AstronomyPictureOfTheDayRequestHandlerDto request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("info AstronomyPictureOfTheDayHandler");

        var response = new AstronomyPictureOfTheDayResponseDto();

        if (await _validator.ValidateAsync(request.RequestDto, cancellationToken)
            is var validation && !validation.IsValid)
        {
            response.AddErrorValidationResult(validation);
            return response;
        }

        if (await _unitOfWork.PictureOfTheDayRepository.GetByDateAsync(request.RequestDto.Date, cancellationToken)
            is var pictureDB && pictureDB is not null)
            return _mapper.Map<AstronomyPictureOfTheDayResponseDto>(pictureDB);

        if (await _nasaPortalClient.GetPictureOfTheDayAsync(request.RequestDto.Date, request.TrackId, cancellationToken)
            is var nasaResponseClient && !nasaResponseClient.IsValid())
        {
            var error = nasaResponseClient.GetError().error;
            response.SetError(new ErrorResponse(error.code, error.message));

            return response;
        }

        var picutreOfTheDayDB = new PictureOfTheDay(
            nasaResponseClient.Copyright,
            nasaResponseClient.Date,
            nasaResponseClient.Explanation,
            nasaResponseClient.Hdurl,
            nasaResponseClient.Title,
            nasaResponseClient.Url);

        PublishQueue(picutreOfTheDayDB);

        return _mapper.Map<AstronomyPictureOfTheDayResponseDto>(nasaResponseClient);
    }

    private void PublishQueue(PictureOfTheDay pictureOfTheDay) =>
        _setupMessageBroker.ProduceMessage(
           JsonSerializer.Serialize(pictureOfTheDay),
           _configuration.RabbitQueuePictureOfTheDay(),
           _configuration.RabbitExchangePictureOfTheDay(),
           _configuration.RabbitRoutingKeyPictureOfTheDay());
}