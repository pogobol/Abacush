using Abacush.Domain.Entities;
using Abacush.Domain.Interfaces;
using Abacush.Infrastructure.Persistence;

namespace Abacush.Infrastructure.Repositories;

public sealed class QualifiedObjectRepository : Repository<QualifiedObject>, IQualifiedObjectRepository
{
    public QualifiedObjectRepository(AbacushDbContext dbContext)
        : base(dbContext)
    {
    }
}
