﻿using Microsoft.AspNetCore.Identity;
using Poc.Nasa.Portal.Infrastructure.Context;

namespace Poc.Nasa.Portal.Api.Configuration;

public static class IdentityConfig
{
    public static void AddIdentityConfiguration(this IServiceCollection services)
    {
        services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = false;
        })
        .AddEntityFrameworkStores<IdentityDataContext>()
        .AddDefaultTokenProviders();
    }
}