using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Poc.Nasa.Portal.App.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApisServiceCollection(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddAppApiServiceCollection(config);
    }
}