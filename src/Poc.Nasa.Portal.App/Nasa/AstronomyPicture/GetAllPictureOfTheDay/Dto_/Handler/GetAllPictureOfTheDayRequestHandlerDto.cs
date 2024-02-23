using MediatR;

namespace Poc.Nasa.Portal.App.Nasa.AstronomyPicture.GetAllPictureOfTheDay;

public sealed class GetAllPictureOfTheDayRequestHandlerDto : IRequest<GetAllPictureOfTheDayResponseHandlerDto>
{
    public GetAllPictureOfTheDayRequestHandlerDto(Guid trackId) =>
        TrackId = trackId;

    public Guid TrackId { get; set; }
}