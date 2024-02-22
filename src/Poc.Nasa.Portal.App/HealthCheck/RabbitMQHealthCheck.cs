using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Poc.Nasa.Portal.Infrastructure.Configurations;
using RabbitMQ.Client;

namespace Poc.Nasa.Portal.App.HealthCheck;

public sealed class RabbitMQHealthCheck : IHealthCheck
{
    private IConfiguration _configuration;
    private IConnection _connection;
    private IConnectionFactory _factory;
    private readonly Uri _rabbitConnectionString;
    private readonly SslOption _sslOption;

#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
    public RabbitMQHealthCheck(IConnection connection, IConfiguration configuration)
    {
        _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }
    public RabbitMQHealthCheck(IConnectionFactory factory, IConfiguration configuration)
    {
        _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public RabbitMQHealthCheck(Uri rabbitConnectionString, SslOption ssl, IConfiguration configuration)
    {
        _rabbitConnectionString = rabbitConnectionString;
        _sslOption = ssl;
        _configuration = configuration;
    }
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken ct = default)
    {
        try
        {
            EnsureConnection();

            using (_connection.CreateModel())
            {
                return Task.FromResult(HealthCheckResult.Healthy("RabbitMQ"));
            }
        }
        catch (Exception ex)
        {
            return Task.FromResult(new HealthCheckResult(context.Registration.FailureStatus, exception: ex));
        }
    }

    private void EnsureConnection()

    {
        if (_connection == null)
        {
            if (_factory == null)
            {
                _factory = new ConnectionFactory()
                {
                    UserName = _configuration.RabbitUsername(),
                    Password = _configuration.RabbitPassord(),
                    VirtualHost = _configuration.RabbitVHost(),
                    HostName = _configuration.RabbitHostname()
                };
            }

            _connection = _factory.CreateConnection();
        }
    }
}