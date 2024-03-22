using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Poc.Nasa.Portal.App.Shared;
using Poc.Nasa.Portal.Infrastructure.Configurations;
using Poc.Nasa.Portal.Infrastructure.Identity;

namespace Poc.Nasa.Portal.App.Nasa.Authentication.Login;

public sealed class LoginHandler : IRequestHandler<LoginRequestHandlerDto, LoginResponseHandlerDto>
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IIdentityService _identityService;
    private readonly LoginValidator _validator;
    private readonly ILogger<LoginHandler> _logger;

    public LoginHandler
    (
        SignInManager<IdentityUser> signInManager,
        IIdentityService identityService,
        LoginValidator validator,
        ILogger<LoginHandler> logger
    )
    {
        _signInManager = signInManager;
        _identityService = identityService;
        _validator = validator;
        _logger = logger;
    }

    public async Task<LoginResponseHandlerDto> Handle(
        LoginRequestHandlerDto request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("info LoginHandler");

        var response = new LoginResponseHandlerDto();

        if (await _validator.ValidateAsync(request.RequestDto, cancellationToken)
            is var validation && !validation.IsValid)
        {
            response.AddErrorValidationResult(validation);
            return response;
        }

        if (await ValidateLoginAsync(request)
            is var responseLoginValidate && responseLoginValidate.IsValid() == false)
            return responseLoginValidate;

        Tuple<string, string> tokens = await _identityService.GenerateCredentialsAsync(request.RequestDto.Email);
        response.AccessToken = tokens.Item1;
        response.RefreshToken = tokens.Item2;

        return response;
    }

    private async Task<LoginResponseHandlerDto> ValidateLoginAsync(LoginRequestHandlerDto request)
    {
        var response = new LoginResponseHandlerDto();

        if (await _signInManager.PasswordSignInAsync(request.RequestDto.Email, request.RequestDto.Password, false, false)
            is var result && result.Succeeded == false)
        {
            if (result.IsLockedOut)
                response.SetError(
                    new ErrorResponse(
                        MessageValidation.AuthUserIsLockedOut.code,
                        MessageValidation.AuthUserIsLockedOut.description
                    ));
            else if (result.IsNotAllowed)
                response.SetError(
                    new ErrorResponse(
                        MessageValidation.AuthUserIsNowAllowed.code,
                        MessageValidation.AuthUserIsNowAllowed.description
                    ));
            else if (result.RequiresTwoFactor)
                response.SetError(
                    new ErrorResponse(
                        MessageValidation.AuthUserRequiresTwoFactors.code,
                        MessageValidation.AuthUserRequiresTwoFactors.description
                    ));
            else
                response.SetError(
                    new ErrorResponse(
                        MessageValidation.AuthUserOrPasswordInvalid.code,
                        MessageValidation.AuthUserOrPasswordInvalid.description
                    ));
        }

        return response;
    }
}