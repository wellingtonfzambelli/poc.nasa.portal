using Microsoft.AspNetCore.Identity;
using Poc.Nasa.Portal.Infrastructure.Context;

namespace Poc.Nasa.Portal.Api.Configuration;

public static class IdentityConfig
{
    public static void AddIdentityConfiguration(this IServiceCollection services)
    {
        services
            .AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<IdentityDataContext>()
            .AddDefaultTokenProviders();
    }
}