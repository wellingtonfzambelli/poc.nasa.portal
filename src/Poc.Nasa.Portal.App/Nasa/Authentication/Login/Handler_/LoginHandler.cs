using MediatR;
using Microsoft.Extensions.Logging;
using Poc.Nasa.Portal.App.Shared;
using Poc.Nasa.Portal.Domain.Models.AuthenticationAggregate;
using Poc.Nasa.Portal.Infrastructure.Authentication;
using Poc.Nasa.Portal.Infrastructure.Configurations;

namespace Poc.Nasa.Portal.App.Nasa.Authentication.Login;

public sealed class LoginHandler : IRequestHandler<LoginRequestHandlerDto, LoginResponseHandlerDto>
{
    private readonly IJWTService _jwtService;
    private readonly LoginValidator _validator;
    private readonly ILogger<LoginHandler> _logger;

    public LoginHandler
    (
        IJWTService jwtService,
        LoginValidator validator,
        ILogger<LoginHandler> logger
    )
    {
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

        if (GetUserByLoginAndPassword(request)
            is var user && user is null)
        {
            response.SetError(
                new ErrorResponse(
                    MessageValidation.UserOrPasswordInvalid.code,
                    MessageValidation.UserOrPasswordInvalid.description
                ));

            return response;
        }

        response.Token = _jwtService.GenerateToken(user);

        return response;
    }

    private User GetUserByLoginAndPassword(LoginRequestHandlerDto request)
    {
        var user = GetUserMock();

        if (user.Email.ToUpper().Trim().Equals(request.RequestDto.Email.ToUpper().Trim()) &&
               user.Password.Trim().Equals(request.RequestDto.Password.Trim()))
            return user;

        return null;
    }

    // TODO: temporary mock
    private User GetUserMock()
    {
        var user = new User("Wellington Zambelli", "wellington.f.zambelli@gmail.com", "132456test");
        user.SetMockedRoles(user);

        return user;
    }
}