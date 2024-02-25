using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Poc.Nasa.Portal.Domain.Shared;
using Poc.Nasa.Portal.Infrastructure.Cache;
using Poc.Nasa.Portal.Infrastructure.Cache.Model;
using Poc.Nasa.Portal.Infrastructure.Configurations;
using Poc.Nasa.Portal.Infrastructure.MessageBroker;
using Poc.Nasa.Portal.Infrastructure.MessageBroker.Messages;
using Poc.Nasa.Portal.Infrastructure.UnitOfWork;
using System.Text.Json;

namespace Poc.Nasa.Portal.Workers.Consumers.PictureOfTheDay;

public sealed class PictureOfTheDayConsumer : IHostedService
{
    private readonly ISetupMessageBroker _setupMessageBroker;
    private readonly ICacheService _cacheService;
    private readonly IConfiguration _configuration;
    private readonly IUnitOfWork _unitOfWork;

    public PictureOfTheDayConsumer
    (
        IConfiguration configuration,
        ICacheService cacheService,
        ISetupMessageBroker setupMessageBroker,
        IUnitOfWork unitOfWork
    )
    {
        _setupMessageBroker = setupMessageBroker;
        _cacheService = cacheService;
        _configuration = configuration;
        _unitOfWork = unitOfWork;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        while (true)
        {
            Console.WriteLine($"### Proccess executing {DateTime.Now} ###");

            try
            {
                if (_setupMessageBroker.ConsumeMessage(_configuration.RabbitQueuePictureOfTheDay())
                    is var message && message is null)
                {
                    await Task.Delay(_configuration.WaitInMillisecondsConsumer());
                    continue;
                }

                var pictureOfTheDayMsg = JsonSerializer.Deserialize<PictureOfTheDayMsg>(message);

                if (await _unitOfWork.PictureOfTheDayRepository.GetByDateAsync(pictureOfTheDayMsg.PictureDate, cancellationToken)
                    is var pictureDB && pictureDB is not null)
                    continue;

                Guid pictureId = await SaveOnDatabaseAsync(pictureOfTheDayMsg, cancellationToken);

                await _cacheService.InsertAsync<PictureOfTheDayRedis>(
                    new PictureOfTheDayRedis
                    {
                        Id = pictureId,
                        HdUrl = pictureOfTheDayMsg.HdUrl,
                        Copyright = pictureOfTheDayMsg.Copyright,
                        Explanation = pictureOfTheDayMsg.Explanation,
                        PictureDate = pictureOfTheDayMsg.PictureDate,
                        Title = pictureOfTheDayMsg.Title,
                        Url = pictureOfTheDayMsg.Url
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something wrong {ex.Message}");
            }
        }
    }

    private async Task<Guid> SaveOnDatabaseAsync(PictureOfTheDayMsg msg, CancellationToken ct)
    {
        Console.WriteLine("Saving on the database");

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

        return picture.Id;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("### Proccess stoping ###");
        Console.WriteLine($"{DateTime.Now}");
    }
}