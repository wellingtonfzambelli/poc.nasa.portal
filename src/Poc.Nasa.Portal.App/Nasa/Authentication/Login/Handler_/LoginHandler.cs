using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Poc.Nasa.Portal.App.Shared;
using Poc.Nasa.Portal.Infrastructure.Authentication;
using Poc.Nasa.Portal.Infrastructure.Configurations;

namespace Poc.Nasa.Portal.App.Nasa.Authentication.Login;

public sealed class LoginHandler : IRequestHandler<LoginRequestHandlerDto, LoginResponseHandlerDto>
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IJWTService _jwtService;

    private readonly LoginValidator _validator;
    private readonly ILogger<LoginHandler> _logger;

    public LoginHandler
    (
        SignInManager<IdentityUser> signInManage,
        IJWTService jwtService,
        LoginValidator validator,
        ILogger<LoginHandler> logger
    )
    {
        _signInManager = signInManage;
        _jwtService = jwtService;
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

        return await AuthUser(request);
    }

    private async Task<LoginResponseHandlerDto> AuthUser(LoginRequestHandlerDto request)
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

        response.Token = _jwtService.GenerateToken(
            request.RequestDto.Email,
            new string[] { "admin" });

        return response;
    }
}