using Abacush.Domain.Interfaces;
using Abacush.Infrastructure.Persistence;

namespace Abacush.Infrastructure.UnitOfWork;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly AbacushDbContext _dbContext;

    public IObjectTypeRepository ObjectTypes { get; }
    public IQualifiedSubjectRepository QualifiedSubjects { get; }
    public IQualifiedObjectRepository QualifiedObjects { get; }
    public IPermissionRepository Permissions { get; }

    public UnitOfWork(
        AbacushDbContext dbContext,
        IObjectTypeRepository objectTypes,
        IQualifiedSubjectRepository qualifiedSubjects,
        IQualifiedObjectRepository qualifiedObjects,
        IPermissionRepository permissions)
    {
        _dbContext = dbContext;
        ObjectTypes = objectTypes;
        QualifiedSubjects = qualifiedSubjects;
        QualifiedObjects = qualifiedObjects;
        Permissions = permissions;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
