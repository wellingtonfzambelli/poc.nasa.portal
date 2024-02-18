using Microsoft.EntityFrameworkCore.Storage;
using Poc.Nasa.Portal.Domain.Models.PictureOfTheDayAggregate;
using Poc.Nasa.Portal.Infrastructure.Configurations;
using Poc.Nasa.Portal.Infrastructure.Domain.Models.PictureOfTheDayAggregate;

namespace Poc.Nasa.Portal.Infrastructure.UnitOfWork;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly NasaPortalContext _context;
    private IPictureOfTheDayRepository _pictureOfTheDayRepository;
    private IDbContextTransaction _transaction;

    public UnitOfWork(NasaPortalContext context) =>
        _context = context;

    public async Task OpenTransactionAsync(CancellationToken ct) =>
        _transaction = await _context.Database.BeginTransactionAsync(ct);

    public void CommitTransaction() =>
        _transaction.Commit();

    public void RollBackTransaction() =>
        _transaction.Rollback();

    public async Task SaveAsync(CancellationToken ct) =>
        await _context.SaveChangesAsync(ct);

    public void Dispose() =>
        _context.Dispose();

    public IPictureOfTheDayRepository PictureOfTheDayRepository =>
        _pictureOfTheDayRepository = _pictureOfTheDayRepository ?? new PictureOfTheDayRepository(_context);
}