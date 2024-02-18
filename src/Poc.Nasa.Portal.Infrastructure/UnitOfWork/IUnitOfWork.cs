using Poc.Nasa.Portal.Domain.Models.PictureOfTheDayAggregate;

namespace Poc.Nasa.Portal.Infrastructure.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IPictureOfTheDayRepository PictureOfTheDayRepository { get; }
    Task SaveAsync(CancellationToken ct);
    Task OpenTransactionAsync(CancellationToken ct);
    void CommitTransaction();
    void RollBackTransaction();
}