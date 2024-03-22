using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Poc.Nasa.Portal.App.Shared;
using Poc.Nasa.Portal.Infrastructure.Configurations;
using System.Text.Json;

namespace Poc.Nasa.Portal.App.Nasa.Authentication.SignUp;

public sealed class SignupHandler : IRequestHandler<SignupRequestHandlerDto, SignupResponseHandlerDto>
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignupValidator _validator;
    private readonly ILogger<SignupHandler> _logger;

    public SignupHandler
    (
        UserManager<IdentityUser> userManager,
        SignupValidator validator,
        ILogger<SignupHandler> logger
    )
    {
        _userManager = userManager;
        _validator = validator;
        _logger = logger;
    }

    public async Task<SignupResponseHandlerDto> Handle(
        SignupRequestHandlerDto request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("info SignupHandler");

        var response = new SignupResponseHandlerDto();

        if (await _validator.ValidateAsync(request.RequestDto, cancellationToken)
            is var validation && !validation.IsValid)
        {
            response.AddErrorValidationResult(validation);
            return response;
        }

        var identity = new IdentityUser
        {
            UserName = request.RequestDto.Email,
            Email = request.RequestDto.Email,
            EmailConfirmed = true
        };

        if (await _userManager.CreateAsync(identity, request.RequestDto.Password)
            is var result && result.Succeeded == false)
        {
            _logger.LogError(JsonSerializer.Serialize(result.Errors));

            response.SetError(
                new ErrorResponse(
                    MessageValidation.GeneralError.code,
                    MessageValidation.GeneralError.description
                ));

            return response;
        }

        return response;
    }
}