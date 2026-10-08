using Abacush.Domain.Entities;
using Abacush.Domain.Interfaces;
using Abacush.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Abacush.Infrastructure.Repositories;

public sealed class PermissionRepository : Repository<Permission>, IPermissionRepository
{
    public PermissionRepository(AbacushDbContext dbContext)
        : base(dbContext)
    {
    }

    public Task<Permission?> GetDetailedByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return DbContext.Permissions
            .Include(permission => permission.Object)
            .Include(permission => permission.Subjects)
            .SingleOrDefaultAsync(permission => permission.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Permission>> ListDetailedAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.Permissions
            .AsNoTracking()
            .Include(permission => permission.Object)
            .Include(permission => permission.Subjects)
            .ToListAsync(cancellationToken);
    }
}
