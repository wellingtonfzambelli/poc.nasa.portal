using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Poc.Nasa.Portal.App.Shared;
using Poc.Nasa.Portal.Infrastructure.UnitOfWork;
using Poc.Nasa.Portal.Integration.NasaPortal;

namespace Poc.Nasa.Portal.App.Nasa.AstronomyPicture;

public sealed class AstronomyPictureOfTheDayHandler : IRequestHandler<AstronomyPictureOfTheDayRequestHandlerDto, AstronomyPictureOfTheDayResponseDto>
{
    private readonly AstronomyPictureOfTheDayValidator _validator;
    private readonly INasaPortalClient _nasaPortalClient;
    private readonly IMapper _mapper;
    private readonly ILogger<AstronomyPictureOfTheDayHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public AstronomyPictureOfTheDayHandler
    (
        AstronomyPictureOfTheDayValidator validator,
        INasaPortalClient nasaPortalClient,
        IMapper mapper,
        ILogger<AstronomyPictureOfTheDayHandler> logger,
        IUnitOfWork unitOfWork
    )
    {
        _validator = validator;
        _nasaPortalClient = nasaPortalClient;
        _mapper = mapper;
        _logger = logger;
        _unitOfWork = unitOfWork;
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
            return null;

        if (await _nasaPortalClient.GetPictureOfTheDayAsync(request.TrackId, cancellationToken)
            is var nasaResponseClient && !nasaResponseClient.IsValid())
        {
            var error = nasaResponseClient.GetError().error;
            response.SetError(new ErrorResponse(error.code, error.message));

            return response;
        }

        await PublishQueueAsync(cancellationToken);

        return _mapper.Map<AstronomyPictureOfTheDayResponseDto>(nasaResponseClient);
    }

    private async Task PublishQueueAsync(CancellationToken ct)
    { 
    }
}