using Microsoft.EntityFrameworkCore;
using Poc.Nasa.Portal.Domain.Models.PictureOfTheDayAggregate;
using Poc.Nasa.Portal.Infrastructure.Configurations;
using Poc.Nasa.Portal.Infrastructure.Shared;

namespace Poc.Nasa.Portal.Infrastructure.Domain.Models.PictureOfTheDayAggregate;

public sealed class PictureOfTheDayRepository : RepositoryBase<PictureOfTheDay, NasaPortalContext>, IPictureOfTheDayRepository
{
    public PictureOfTheDayRepository(NasaPortalContext _context) : base(_context) { }

    public async Task<IList<PictureOfTheDay>> GetAllAsync(CancellationToken ct) =>
      await base.Context.PictureOfTheDay.OrderByDescending(s => s.PictureDate).ToListAsync(ct);

    public async Task<PictureOfTheDay> GetByDateAsync(DateTime dateOfPicture, CancellationToken ct) =>
      await base.Context.PictureOfTheDay.FirstOrDefaultAsync(s => s.PictureDate == dateOfPicture, ct);
}