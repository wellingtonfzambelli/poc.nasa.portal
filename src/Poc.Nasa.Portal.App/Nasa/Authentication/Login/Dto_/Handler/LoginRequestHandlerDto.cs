using MediatR;

namespace Poc.Nasa.Portal.App.Nasa.Authentication.Login;

public sealed class LoginRequestHandlerDto : IRequest<LoginResponseHandlerDto>
{
    public LoginRequestHandlerDto(LoginRequestDto request, Guid trackId)
    {
        RequestDto = request;
        TrackId = trackId;
    }

    public Guid TrackId { get; set; }
    public LoginRequestDto RequestDto { get; set; }
}