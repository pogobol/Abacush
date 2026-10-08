using Abacush.Domain.Entities;
using Abacush.Domain.Interfaces;
using Abacush.Infrastructure.Persistence;

namespace Abacush.Infrastructure.Repositories;

public sealed class QualifiedTypeRepository : Repository<QualifiedType>, IQualifiedTypeRepository
{
    public QualifiedTypeRepository(AbacushDbContext dbContext)
        : base(dbContext)
    {
    }
}
