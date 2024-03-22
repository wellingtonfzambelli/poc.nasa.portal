using MediatR;

namespace Poc.Nasa.Portal.App.Nasa.Authentication.SignUp;

public sealed class SignupRequestHandlerDto : IRequest<SignupResponseHandlerDto>
{
    public SignupRequestHandlerDto(SignupRequestDto request, Guid trackId)
    {
        RequestDto = request;
        TrackId = trackId;
    }

    public Guid TrackId { get; set; }
    public SignupRequestDto RequestDto { get; set; }
}