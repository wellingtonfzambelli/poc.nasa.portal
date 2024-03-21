using Poc.Nasa.Portal.App.Shared;

namespace Poc.Nasa.Portal.App.Nasa.Authentication.Login;

public sealed class LoginResponseHandlerDto : BaseResponseDto
{
    public string Token { get; set; }
}