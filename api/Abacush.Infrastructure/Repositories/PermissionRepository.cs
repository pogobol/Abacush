using Abacush.Domain.Entities;
using Abacush.Domain.Interfaces;
using Abacush.Infrastructure.Persistence;

namespace Abacush.Infrastructure.Repositories;

public sealed class PermissionRepository : Repository<Permission>, IPermissionRepository
{
    public PermissionRepository(AbacushDbContext dbContext)
        : base(dbContext)
    {
    }
}
