using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Poc.Nasa.Portal.Domain.Models.AuthenticationAggregate;
using Poc.Nasa.Portal.Infrastructure.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Poc.Nasa.Portal.Infrastructure.Authentication;

public sealed class JWTService : IJWTService
{
    private readonly IConfiguration _configuration;

    public JWTService(IConfiguration configuration) =>
        _configuration = configuration;

    public string GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email)
        };
        claims.AddRange(user.Roles.Select(p => new Claim(ClaimTypes.Role, p.Desscription)));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Audience = _configuration.JwtAudience(),
            Issuer = _configuration.JwtIssuer(),
            Expires = DateTime.UtcNow.AddMinutes(_configuration.JwtExpiresInMinutes()),
            SigningCredentials = new SigningCredentials
            (
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.JwtSecret())),
                SecurityAlgorithms.HmacSha512Signature
            )
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}