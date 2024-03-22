using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Poc.Nasa.Portal.App.Shared;
using Poc.Nasa.Portal.Infrastructure.Configurations;
using Poc.Nasa.Portal.Infrastructure.Identity;

namespace Poc.Nasa.Portal.App.Nasa.Authentication.RefreshLogin;

public sealed class RefreshLoginHandler : IRequestHandler<RefreshLoginRequestHandlerDto, RefreshLoginResponseHandlerDto>
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IIdentityService _identityService;
    private readonly ILogger<RefreshLoginHandler> _logger;

    public RefreshLoginHandler
    (
        UserManager<IdentityUser> userManagerManage,
        IIdentityService identityService,
        ILogger<RefreshLoginHandler> logger
    )
    {
        _userManager = userManagerManage;
        _identityService = identityService;
        _logger = logger;
    }

    public async Task<RefreshLoginResponseHandlerDto> Handle(
        RefreshLoginRequestHandlerDto request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("info RefreshLoginHandler");

        var response = new RefreshLoginResponseHandlerDto();

        if (await _userManager.FindByIdAsync(request.RequestDto.UserId.ToString())
            is var user && user is null)
        {
            response.SetError(
                    new ErrorResponse(
                        MessageValidation.AuthUserNotFound.code,
                        MessageValidation.AuthUserNotFound.description
                    ));

            return response;
        }

        if (await ValidateUserLoginAsync(user, request)
            is var responseValidate && responseValidate.IsValid() == false)
            return responseValidate;

        Tuple<string, string> tokens = await _identityService.GenerateCredentialsAsync(user.Email);
        response.AccessToken = tokens.Item1;
        response.RefreshToken = tokens.Item2;

        return response;
    }

    private async Task<RefreshLoginResponseHandlerDto> ValidateUserLoginAsync(
        IdentityUser user, RefreshLoginRequestHandlerDto request)
    {
        var response = new RefreshLoginResponseHandlerDto();

        if (await _userManager.IsLockedOutAsync(user))
            response.SetError(
                new ErrorResponse(
                    MessageValidation.AuthUserIsLockedOut.code,
                    MessageValidation.AuthUserIsLockedOut.description
                ));
        else if (await _userManager.IsEmailConfirmedAsync(user) == false)
            response.SetError(
                new ErrorResponse(
                    MessageValidation.AuthUserIsNowAllowed.code,
                    MessageValidation.AuthUserIsNowAllowed.description
                ));

        return response;

    }
}