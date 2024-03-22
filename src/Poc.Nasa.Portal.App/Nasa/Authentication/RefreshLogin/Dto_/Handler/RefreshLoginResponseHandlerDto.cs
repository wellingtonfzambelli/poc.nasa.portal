using Poc.Nasa.Portal.App.Shared;

namespace Poc.Nasa.Portal.App.Nasa.Authentication.RefreshLogin;

public sealed class RefreshLoginResponseHandlerDto : BaseResponseDto
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}