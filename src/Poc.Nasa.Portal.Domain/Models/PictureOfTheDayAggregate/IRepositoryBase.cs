using System.Linq.Expressions;

namespace Poc.Nasa.Portal.Domain.Models.PictureOfTheDayAggregate;

public interface IRepositoryBase<TEntity> where TEntity : class
{
    Task<TEntity> FindAsync(int id, CancellationToken ct);

    Task<TEntity> FindAsync(Guid id, CancellationToken ct);

    Task<IEnumerable<TEntity>> FindAllAsync(CancellationToken ct);

    Task<IEnumerable<TEntity>> FindByConditionAync(
        Expression<Func<TEntity, bool>> expression, CancellationToken ct);

    Task CreateAsync(TEntity entity, CancellationToken ct);

    void Update(TEntity entity);

    void Delete(TEntity entity);
}