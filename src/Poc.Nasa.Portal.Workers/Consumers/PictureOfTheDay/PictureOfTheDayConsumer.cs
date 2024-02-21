using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Poc.Nasa.Portal.Infrastructure.Configurations;
using Poc.Nasa.Portal.Infrastructure.MessageBroker;
using System.Text.Json;

namespace Poc.Nasa.Portal.Workers.Consumers.PictureOfTheDay;

public sealed class PictureOfTheDayConsumer : BackgroundService
{
    private readonly ISetupMessageBroker _setupMessageBroker;
    private readonly IConfiguration _configuration;

    public PictureOfTheDayConsumer(IConfiguration configuration, ISetupMessageBroker setupMessageBroker)
    {
        _setupMessageBroker = setupMessageBroker;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Getting message...");
        var message = _setupMessageBroker.ConsumeMessage(_configuration.RabbitQueuePictureOfTheDay());
        var ob = JsonSerializer.Deserialize<Domain.Models.PictureOfTheDayAggregate.PictureOfTheDay>(message);
    }
}