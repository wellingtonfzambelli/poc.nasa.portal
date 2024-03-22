using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Poc.Nasa.Portal.App.Shared;
using Poc.Nasa.Portal.Infrastructure.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Poc.Nasa.Portal.App.Nasa.Authentication.Login;

public sealed class LoginHandler : IRequestHandler<LoginRequestHandlerDto, LoginResponseHandlerDto>
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    private readonly LoginValidator _validator;
    private readonly ILogger<LoginHandler> _logger;
    private readonly IConfiguration _configuration;

    public LoginHandler
    (
        SignInManager<IdentityUser> signInManage,
        UserManager<IdentityUser> userManagerManage,
        LoginValidator validator,
        ILogger<LoginHandler> logger,
        IConfiguration configuration
    )
    {
        _signInManager = signInManage;
        _userManager = userManagerManage;
        _validator = validator;
        _logger = logger;
        _configuration = configuration;
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

        response.Token = await GenerateTokenAsync(request.RequestDto.Email);

        return response;
    }

    private async Task<string> GenerateTokenAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        var claims = await GetClaimsAsync(user);
        DateTime expirationDate = DateTime.Now.AddMinutes(1);

        var jwt = new JwtSecurityToken(
            issuer: _configuration.JwtIssuer(),
            audience: _configuration.JwtAudience(),
            claims: claims,
            notBefore: DateTime.Now,
            expires: expirationDate,
            signingCredentials: new SigningCredentials
            (
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.JwtSecret())),
                SecurityAlgorithms.HmacSha512
            ));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    private async Task<IList<Claim>> GetClaimsAsync(IdentityUser user)
    {
        var claims = await _userManager.GetClaimsAsync(user);

        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
        claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

        await SetRoleToClaimsAsync(claims, user);

        return claims;
    }

    private async Task SetRoleToClaimsAsync(IList<Claim> claims, IdentityUser user)
    {
        var roles = await _userManager.GetRolesAsync(user);

        foreach (var role in roles)
            claims.Add(new Claim("Role", role));
    }
}