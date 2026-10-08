namespace Abacush.Domain.Interfaces;

public interface IUnitOfWork
{
    IQualifiedTypeRepository QualifiedTypes { get; }
    IQualifiedSubjectRepository QualifiedSubjects { get; }
    IQualifiedObjectRepository QualifiedObjects { get; }
    IPermissionRepository Permissions { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
