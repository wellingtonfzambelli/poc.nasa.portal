using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Poc.Nasa.Portal.Infrastructure.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Poc.Nasa.Portal.Infrastructure.Identity;

public sealed class IdentityService : IIdentityService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IConfiguration _configuration;

    public IdentityService(UserManager<IdentityUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<Tuple<string, string>> GenerateCredentialsAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        var accessTokenClaims = await GetClaimsAsync(user);
        var refreshTokenClaims = await GetClaimsAsync(user, true);

        var expirationDateAccessToken = DateTime.Now.AddMinutes(_configuration.JwtAccessTokenExpiresInMinutes());
        var expirationDateRefreshToken = DateTime.Now.AddMinutes(_configuration.JwtRefreshTokenExpiresInMinutes());

        var accessToken = GenerateToken(accessTokenClaims, expirationDateAccessToken);
        var refreshToken = GenerateToken(refreshTokenClaims, expirationDateRefreshToken);

        return new Tuple<string, string>(accessToken, refreshToken);
    }

    private string GenerateToken(IEnumerable<Claim> claims, DateTime expirationDate)
    {
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

    private async Task<IList<Claim>> GetClaimsAsync(IdentityUser user, bool isRefreshToken = false)
    {
        var claims = new List<Claim>();
        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
        claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

        if (isRefreshToken == false)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);

            await SetRoleToClaimsAsync(claims, user);
        }

        return claims;
    }

    private async Task SetRoleToClaimsAsync(IList<Claim> claims, IdentityUser user)
    {
        var roles = await _userManager.GetRolesAsync(user);

        foreach (var role in roles)
            claims.Add(new Claim("Role", role));
    }
}