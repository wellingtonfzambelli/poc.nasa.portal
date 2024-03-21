using Poc.Nasa.Portal.Api.Filters;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Poc.Nasa.Portal.Api.Configuration;

public static class ControllerConfig
{
    public static void AddControllerConfiguration(this IServiceCollection services)
    {
        services.AddControllers(config =>
        {
            config.Filters.Add(typeof(ExceptionFilter));
        })
        .AddJsonOptions
        (
            opts => opts.JsonSerializerOptions.Converters.Add
            (
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
            )
        );
    }
}