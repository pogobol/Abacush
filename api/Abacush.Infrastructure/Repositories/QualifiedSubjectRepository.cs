using Abacush.Domain.Entities;
using Abacush.Domain.Interfaces;
using Abacush.Infrastructure.Persistence;

namespace Abacush.Infrastructure.Repositories;

public sealed class QualifiedSubjectRepository : Repository<QualifiedSubject>, IQualifiedSubjectRepository
{
    public QualifiedSubjectRepository(AbacushDbContext dbContext)
        : base(dbContext)
    {
    }
}
