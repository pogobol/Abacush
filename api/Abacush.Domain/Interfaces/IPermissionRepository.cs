using Abacush.Domain.Entities;

namespace Abacush.Domain.Interfaces;

public interface IPermissionRepository : IRepository<Permission>
{
    Task<Permission?> GetDetailedByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Permission>> ListDetailedAsync(CancellationToken cancellationToken = default);
}
