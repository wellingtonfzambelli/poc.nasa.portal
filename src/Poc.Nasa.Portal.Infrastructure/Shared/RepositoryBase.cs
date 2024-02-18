using Microsoft.EntityFrameworkCore;
using Poc.Nasa.Portal.Domain.Models.Shared;
using System.Linq.Expressions;

namespace Poc.Nasa.Portal.Infrastructure.Shared;

public abstract class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity> where TEntity : class
                                                                                   where TContext : DbContext
{
    public TContext Context { get; set; }

    public RepositoryBase(TContext context) =>
        Context = context;

    public async Task<TEntity> FindAsync(Guid id, CancellationToken ct) =>
        await Context.Set<TEntity>().FindAsync(id, ct);

    public async Task<IEnumerable<TEntity>> FindAllAsync(CancellationToken ct) =>
        await Context.Set<TEntity>().ToListAsync(ct);

    public async Task<IEnumerable<TEntity>> FindByConditionAync(
        Expression<Func<TEntity, bool>> expression, CancellationToken ct) =>
        await Context.Set<TEntity>().Where(expression).ToListAsync(ct);

    public async Task CreateAsync(TEntity entity, CancellationToken ct) =>
        await Context.Set<TEntity>().AddAsync(entity, ct);

    public void Update(TEntity entity) =>
        Context.Set<TEntity>().Update(entity);

    public void Delete(TEntity entity) =>
        Context.Set<TEntity>().Remove(entity);
}