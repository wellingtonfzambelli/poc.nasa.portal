﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Poc.Nasa.Portal.App.Shared;
using Poc.Nasa.Portal.Domain.Models.PictureOfTheDayAggregate;
using Poc.Nasa.Portal.Infrastructure.Cache;
using Poc.Nasa.Portal.Infrastructure.Configurations;
using Poc.Nasa.Portal.Infrastructure.MessageBroker;
using Poc.Nasa.Portal.Infrastructure.UnitOfWork;
using Poc.Nasa.Portal.Integration.NasaPortal;
using System.Text.Json;

namespace Poc.Nasa.Portal.App.Nasa.AstronomyPicture.GetPictureOfTheDay;

public sealed class GetPictureOfTheDayHandler : IRequestHandler<GetPictureOfTheDayRequestHandlerDto, GetPictureOfTheDayResponseHandlerDto>
{
    private readonly GetPictureOfTheDayValidator _validator;
    private readonly INasaPortalClient _nasaPortalClient;
    private readonly ICacheService _cacheService;
    private readonly IMapper _mapper;
    private readonly ILogger<GetPictureOfTheDayHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISetupMessageBroker _setupMessageBroker;
    private readonly IConfiguration _configuration;

    public GetPictureOfTheDayHandler
    (
        GetPictureOfTheDayValidator validator,
        INasaPortalClient nasaPortalClient,
        ICacheService cacheService,
        IMapper mapper,
        ILogger<GetPictureOfTheDayHandler> logger,
        IUnitOfWork unitOfWork,
        ISetupMessageBroker setupMessageBroker,
        IConfiguration configuration
    )
    {
        _validator = validator;
        _nasaPortalClient = nasaPortalClient;
        _cacheService = cacheService;
        _mapper = mapper;
        _logger = logger;
        _unitOfWork = unitOfWork;
        _setupMessageBroker = setupMessageBroker;
        _configuration = configuration;
    }

    public async Task<GetPictureOfTheDayResponseHandlerDto> Handle(
        GetPictureOfTheDayRequestHandlerDto request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("info AstronomyPictureOfTheDayHandler");

        var response = new GetPictureOfTheDayResponseHandlerDto();

        if (await _validator.ValidateAsync(request.RequestDto, cancellationToken)
            is var validation && !validation.IsValid)
        {
            response.AddErrorValidationResult(validation);
            return response;
        }

        if (await _unitOfWork.PictureOfTheDayRepository.GetByDateAsync(request.RequestDto.Date, cancellationToken)
            is var pictureDB && pictureDB is not null)
            return _mapper.Map<GetPictureOfTheDayResponseHandlerDto>(pictureDB);

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

        return _mapper.Map<GetPictureOfTheDayResponseHandlerDto>(nasaResponseClient);
    }

    private void PublishQueue(PictureOfTheDay pictureOfTheDay) =>
        _setupMessageBroker.ProduceMessage(
           JsonSerializer.Serialize(pictureOfTheDay),
           _configuration.RabbitQueuePictureOfTheDay(),
           _configuration.RabbitExchangePictureOfTheDay(),
           _configuration.RabbitRoutingKeyPictureOfTheDay());
}