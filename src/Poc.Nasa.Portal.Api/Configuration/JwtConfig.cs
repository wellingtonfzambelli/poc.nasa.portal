using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Poc.Nasa.Portal.Infrastructure.Authentication;
using Poc.Nasa.Portal.Infrastructure.Configurations;
using System.Text;
namespace Poc.Nasa.Portal.Api.Configuration;

public static class JwtConfig
{
    public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton<IJWTService, JWTService>();

        services.AddAuthentication(p =>
        {
            p.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            p.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(p =>
        {
            p.RequireHttpsMetadata = false; // should be 'true' in production
            p.SaveToken = true;
            p.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.JwtSecret())),

                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,

                ValidIssuer = config.JwtIssuer(),
                ValidAudience = config.JwtAudience()
            };
        });
    }

    public static void UseJwtConfiguration(this IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}