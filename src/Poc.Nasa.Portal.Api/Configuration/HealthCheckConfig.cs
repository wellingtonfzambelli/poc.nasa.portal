using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Poc.Nasa.Portal.App.HealthCheck;
using Poc.Nasa.Portal.Infrastructure.Configurations;
using RabbitMQ.Client;

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

    public static IHealthChecksBuilder AddHealthCheckRabbitMQ
    (
        this IHealthChecksBuilder builder,
        string rabbitConnectionString,
        IConfiguration configuration,
        SslOption sslOption = null,
        string name = default,
        HealthStatus? failureStatus = default,
        IEnumerable<string> tags = default, TimeSpan? timeout = default
    )
    {
        builder.Services.AddSingleton(sp => new RabbitMQHealthCheck(new ConnectionFactory()
        {
            UserName = configuration.RabbitUsername(),
            Password = configuration.RabbitPassord(),
            VirtualHost = configuration.RabbitVHost(),
            HostName = configuration.RabbitHostname()
        }, configuration));

        var hc = new HealthCheckRegistration(
            name ?? "rabbitmq",
            sp => sp.GetRequiredService<RabbitMQHealthCheck>(),
            failureStatus,
            tags,
            timeout);

        hc.FailureStatus = hc.FailureStatus == HealthStatus.Healthy ?
            HealthStatus.Healthy : HealthStatus.Degraded;

        return builder.Add(hc);
    }

    public static IHealthChecksBuilder AddHealthCheckMySql
        (
            this IHealthChecksBuilder builder,
            string connectionString,
            string healthQuery = default,
            string name = default,
            HealthStatus? failureStatus = default,
            IEnumerable<string> tags = default,
            TimeSpan? timeout = default,
            Action<MySqlConnection> beforeOpenConnectionConfigurer = default
        ) =>
        builder.AddHealthCheckMySql(_ => connectionString, healthQuery, name, failureStatus, tags, timeout, beforeOpenConnectionConfigurer);

    private static IHealthChecksBuilder AddHealthCheckMySql
    (
      this IHealthChecksBuilder builder,
      Func<IServiceProvider, string> connectionStringFactory,
      string healthQuery = default,
      string name = default,
      HealthStatus? failureStatus = default,
      IEnumerable<string> tags = default,
      TimeSpan? timeout = default,
      Action<MySqlConnection> beforeOpenConnectionConfigurer = default
    )
    {
        if (connectionStringFactory == null)
            throw new ArgumentNullException(nameof(connectionStringFactory));

        var hc = new HealthCheckRegistration(
            name ?? "mysql",
            sp => new MysqlHealthCheck(connectionStringFactory(sp), healthQuery ?? "SELECT 1;", beforeOpenConnectionConfigurer),
            failureStatus,
            tags,
            timeout);

        hc.FailureStatus = hc.FailureStatus == HealthStatus.Healthy ?
            HealthStatus.Healthy : HealthStatus.Degraded;

        return builder.Add(hc);
    }

    private static Task WriteResponse(HttpContext httpContext, HealthReport result)
    {
        httpContext.Response.ContentType = "text/plan";
        return httpContext.Response.WriteAsync(result.Status.ToString());
    }
}