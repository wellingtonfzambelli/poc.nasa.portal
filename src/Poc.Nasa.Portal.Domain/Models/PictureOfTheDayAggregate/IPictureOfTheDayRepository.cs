using Poc.Nasa.Portal.Domain.Models.Shared;

namespace Poc.Nasa.Portal.Domain.Models.PictureOfTheDayAggregate;

public interface IPictureOfTheDayRepository : IRepositoryBase<PictureOfTheDay>
{
    Task<IList<PictureOfTheDay>> GetAllAsync(CancellationToken ct);
    Task<PictureOfTheDay> GetByDateAsync(DateTime dateOfPicture, CancellationToken ct);
}