using MediatR;

namespace Poc.Nasa.Portal.App.Nasa.AstronomyPicture.GetPictureOfTheDay;

public sealed class GetPictureOfTheDayRequestHandlerDto : IRequest<GetPictureOfTheDayResponseDto>
{
    public GetPictureOfTheDayRequestHandlerDto(GetPictureOfTheDayRequestDto request, Guid trackId)
    {
        RequestDto = request;
        TrackId = trackId;
    }

    public Guid TrackId { get; set; }
    public GetPictureOfTheDayRequestDto RequestDto { get; set; }
}