using Poc.Nasa.Portal.Infrastructure.Configurations;
using Redis.OM;

namespace Poc.Nasa.Portal.Api.Configuration;

public static class RedisConfig
{
    public static void AddRedisConfiguration(this IServiceCollection services, IConfiguration config)
    {
        var provider = new RedisConnectionProvider(config.RedisServer());
        services.AddSingleton(provider);
    }
}