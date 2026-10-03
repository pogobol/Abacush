using Abacush.Domain.Interfaces;
using Abacush.Infrastructure.Persistence;

namespace Abacush.Infrastructure.UnitOfWork;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly AbacushDbContext _dbContext;

    public UnitOfWork(AbacushDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
