using MediatR;

namespace Poc.Nasa.Portal.App.Nasa.AstronomyPicture;

public sealed class AstronomyPictureOfTheDayRequestHandlerDto : IRequest<AstronomyPictureOfTheDayResponseDto>
{
    public AstronomyPictureOfTheDayRequestHandlerDto(AstronomyPictureOfTheDayRequestDto request, Guid trackId)
    {
        RequestDto = request;
        TrackId = trackId;
    }

    public AstronomyPictureOfTheDayRequestDto RequestDto { get; set; }
    public Guid TrackId { get; set; }
}