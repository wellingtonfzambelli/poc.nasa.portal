﻿using Microsoft.Extensions.Diagnostics.HealthChecks;
using MySql.Data.MySqlClient;
using Poc.Nasa.Portal.App.Extensions;
using Poc.Nasa.Portal.App.HealthCheck;
using RabbitMQ.Client;

namespace Poc.Nasa.Portal.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddServiceCollection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
        services.AddApisServiceCollection(configuration);
    }

    // HealthCheck RabbitMQ
    private const string RABBIT_NAME = "rabbitmq";
    public static IHealthChecksBuilder AddHealthCheckRabbitMQ
    (
        this IHealthChecksBuilder builder,
        string rabbitConnectionString,
        SslOption sslOption = null,
        string name = default,
        HealthStatus? failureStatus = default,
        IEnumerable<string> tags = default,
        TimeSpan? timeout = default
    )
    {
        builder.Services.AddSingleton(sp => new RabbitMQHealthCheck(sp.GetRequiredService<ConnectionFactory>()));

        var hc = new HealthCheckRegistration(
            name ?? RABBIT_NAME,
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
}