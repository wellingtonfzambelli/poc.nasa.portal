using MediatR;

namespace Poc.Nasa.Portal.App.Nasa.AstronomyPicture.GetPictureOfTheDay;

public sealed class AstronomyPictureOfTheDayRequestHandlerDto : IRequest<AstronomyPictureOfTheDayResponseDto>
{
    public AstronomyPictureOfTheDayRequestHandlerDto(AstronomyPictureOfTheDayRequestDto request, Guid trackId)
    {
        RequestDto = request;
        TrackId = trackId;
    }

    public Guid TrackId { get; set; }
    public AstronomyPictureOfTheDayRequestDto RequestDto { get; set; }
}