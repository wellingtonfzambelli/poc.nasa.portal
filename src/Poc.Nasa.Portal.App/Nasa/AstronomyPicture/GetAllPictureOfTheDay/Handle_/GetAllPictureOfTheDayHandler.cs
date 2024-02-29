using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Poc.Nasa.Portal.App.Shared;
using Poc.Nasa.Portal.Domain.Models.PictureOfTheDayAggregate;
using Poc.Nasa.Portal.Infrastructure.Configurations;
using Poc.Nasa.Portal.Infrastructure.UnitOfWork;

namespace Poc.Nasa.Portal.App.Nasa.AstronomyPicture.GetAllPictureOfTheDay;

public sealed class GetAllPictureOfTheDayHandler : IRequestHandler<GetAllPictureOfTheDayRequestHandlerDto, GetAllPictureOfTheDayResponseHandlerDto>
{
    private readonly ILogger<GetAllPictureOfTheDayHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllPictureOfTheDayHandler
    (
        ILogger<GetAllPictureOfTheDayHandler> logger,
        IUnitOfWork unitOfWork,
        IMapper mapper
    )
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetAllPictureOfTheDayResponseHandlerDto> Handle(
        GetAllPictureOfTheDayRequestHandlerDto request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("info GetAllPictureOfTheDayHandler");

        var response = new GetAllPictureOfTheDayResponseHandlerDto();

        if (await _unitOfWork.PictureOfTheDayRepository.GetAllAsync(cancellationToken)
            is var picture && picture is null)
        {
            response.SetError(new ErrorResponse(
                MessageValidation.NoDataFound.code,
                MessageValidation.NoDataFound.description));

            return response; 
        }

        response.PicturesOfTheDay = _mapper.Map<IList<PictureOfTheDay>, IList<GetAllPictureOfTheDayResponseDto>>(picture);
        return response;
    }
}