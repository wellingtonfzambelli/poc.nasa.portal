using MediatR;

namespace Poc.Nasa.Portal.App.Nasa.Authentication.RefreshLogin;

public sealed class RefreshLoginRequestHandlerDto : IRequest<RefreshLoginResponseHandlerDto>
{
    public RefreshLoginRequestHandlerDto(RefreshLoginRequestDto request, Guid trackId)
    {
        RequestDto = request;
        TrackId = trackId;
    }

    public Guid TrackId { get; set; }
    public RefreshLoginRequestDto RequestDto { get; set; }
}