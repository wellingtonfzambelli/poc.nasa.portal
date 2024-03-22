using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Poc.Nasa.Portal.Infrastructure.Configurations;
using System.Text;
namespace Poc.Nasa.Portal.Api.Configuration;

public static class AuthenticationConfig
{
    public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration config)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.JwtSecret()));

        // Password requirements
        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 8;
        });

        // Token requirements
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = config.JwtIssuer(),

            ValidateAudience = true,
            ValidAudience = config.JwtAudience(),

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = securityKey,

            RequireExpirationTime = true,
            ValidateLifetime = true,

            ClockSkew = TimeSpan.Zero
        };

        // .Net enables bearer token authentication
        services.AddAuthentication(p =>
        {
            p.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            p.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        // .Net uses what we especified above
        .AddJwtBearer(p =>
        {
            p.RequireHttpsMetadata = false; // should be 'true' in production
            p.SaveToken = true;
            p.TokenValidationParameters = tokenValidationParameters;
        });
    }

    public static void UseJwtConfiguration(this IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }

    public static void AddAuthorizationPolicies(this IServiceCollection services)
    {
        // This is a example of policy rule
        // You should add above the controller or method the follow annotation: [Authorize(Policies = "my_policy_name")]

        //services.AddSingleton<IAuthorizationHandler, BusinessHourHandler>();
        //services.AddAuthorization(options =>
        //{
        //    options.AddPolicy(Policies.BusinessHour, policy =>
        //        policy.Requirements.Add(new BusinessHourRequirement()));
        //});
    }
}