using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Poc.Nasa.Portal.Domain.Shared;
using Poc.Nasa.Portal.Infrastructure.Configurations;
using Poc.Nasa.Portal.Infrastructure.MessageBroker;
using Poc.Nasa.Portal.Infrastructure.MessageBroker.Messages;
using Poc.Nasa.Portal.Infrastructure.UnitOfWork;
using System.Text.Json;

namespace Poc.Nasa.Portal.Workers.Consumers.PictureOfTheDay;

public sealed class PictureOfTheDayConsumer : BackgroundService
{
    private readonly ISetupMessageBroker _setupMessageBroker;
    private readonly IConfiguration _configuration;
    private readonly IUnitOfWork _unitOfWork;

    public PictureOfTheDayConsumer
    (
        IConfiguration configuration,
        ISetupMessageBroker setupMessageBroker,
        IUnitOfWork unitOfWork
    )
    {
        _setupMessageBroker = setupMessageBroker;
        _configuration = configuration;
        _unitOfWork = unitOfWork;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Getting message...");

        try
        {
            if (_setupMessageBroker.ConsumeMessage(_configuration.RabbitQueuePictureOfTheDay())
                is var message && message is null)
                return;

            var pictureOfTheDayMsg = JsonSerializer.Deserialize<PictureOfTheDayMsg>(message);

            await SaveAsync(pictureOfTheDayMsg, stoppingToken);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Something wrong {ex.Message}");
        }
    }

    private async Task SaveAsync(PictureOfTheDayMsg msg, CancellationToken ct)
    {
        var picture = new Domain.Models.PictureOfTheDayAggregate.PictureOfTheDay
                (
                    msg.Copyright,
                    msg.PictureDate,
                    msg.Explanation.Truncate(1000),
                    msg.HdUrl.Truncate(5000),
                    msg.Title,
                    msg.Url.Truncate(5000)
                );

        await _unitOfWork.PictureOfTheDayRepository.CreateAsync(picture, ct);
        await _unitOfWork.SaveAsync(ct);
    }
}