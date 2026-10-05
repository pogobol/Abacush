using Abacush.Domain.Interfaces;
using Abacush.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Abacush.Infrastructure.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    protected AbacushDbContext DbContext { get; }

    protected DbSet<TEntity> Entities => DbContext.Set<TEntity>();

    public Repository(AbacushDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<TEntity?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await Entities.FindAsync([id], cancellationToken);
    }

    public async Task<IReadOnlyList<TEntity>> ListAsync(
        CancellationToken cancellationToken = default)
    {
        return await Entities
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public void Add(TEntity entity)
    {
        Entities.Add(entity);
    }

    public void Remove(TEntity entity)
    {
        Entities.Remove(entity);
    }
}
