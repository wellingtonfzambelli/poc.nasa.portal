using Poc.Nasa.Portal.Infrastructure.Configurations;
using Poc.Nasa.Portal.Infrastructure.MessageBroker;

namespace Poc.Nasa.Portal.Api.Configuration;

public static class RabbitConfig
{
    public static void AddRabbitConfiguration(this IServiceCollection services, IConfiguration config) =>
        services.AddScoped<ISetupMessageBroker>(p =>
        new SetupMessageBroker(
            config.RabbitHostname(),
            config.RabbitVHost(),
            config.RabbitUsername(),
            config.RabbitPassord())
        );
}