using Abacush.Domain.Entities;
using Abacush.Domain.Interfaces;
using Abacush.Infrastructure.Persistence;

namespace Abacush.Infrastructure.Repositories;

public sealed class ObjectTypeRepository : Repository<ObjectType>, IObjectTypeRepository
{
    public ObjectTypeRepository(AbacushDbContext dbContext)
        : base(dbContext)
    {
    }
}
