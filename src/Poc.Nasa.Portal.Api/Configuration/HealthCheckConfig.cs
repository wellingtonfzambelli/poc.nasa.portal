using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Poc.Nasa.Portal.Api.Extensions;
using Poc.Nasa.Portal.App.HealthCheck;
using Poc.Nasa.Portal.Infrastructure.Configurations;

namespace Poc.Nasa.Portal.Api.Configuration;

public static class HealthCheckConfig
{
    public static void AddHealthCheckConfiguration(this IServiceCollection services, IConfiguration config)
    {
        string rabbitConnection = $"amqps://{config.RabbitUsername()}:{config.RabbitPassord()}@{config.RabbitHostname()}/{config.RabbitVHost()}";

        services.AddHealthChecks()
        .AddHealthCheckMySql(config.ConnectionString(), name: "MySQL")
        .AddHealthCheckRabbitMQ(rabbitConnection, config, name: "RabbitMQ")
        .AddRedis(config.RedisServer().Replace("redis://", ""), "Redis", HealthStatus.Degraded)
        .AddCheck<GCInfoHealthCheck>("GC");
    }

    public static void UseHealthCheckConfiguration(this IApplicationBuilder app)
    {
        app.UseHealthChecks("/nasa/v1/health/live", new HealthCheckOptions()
        {
            Predicate = _ => true,
            ResponseWriter = WriteResponse
        });
        app.UseHealthChecks("/nasa/v1/health/ready", new HealthCheckOptions()
        {
            ResponseWriter = (httpContext, result) =>
            {
                httpContext.Response.ContentType = "application/json";

                var json = new JObject(
                    new JProperty("status", result.Status.ToString()),
                    new JProperty("results", new JObject(result.Entries.Select(pair =>
                        new JProperty(pair.Key, new JObject(
                            new JProperty("status", pair.Value.Status.ToString()),
                            new JProperty("description", pair.Value.Description),
                            new JProperty("data", new JObject(pair.Value.Data.Select(
                                p => new JProperty(p.Key, p.Value))))))))));

                return httpContext.Response.WriteAsync(json.ToString(Formatting.Indented));
            }
        });
    }

    private static Task WriteResponse(HttpContext httpContext, HealthReport result)
    {
        httpContext.Response.ContentType = "text/plan";
        return httpContext.Response.WriteAsync(result.Status.ToString());
    }
}