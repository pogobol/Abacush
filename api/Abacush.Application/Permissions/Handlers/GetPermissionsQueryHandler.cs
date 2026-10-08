using Abacush.Application.Permissions.Dtos;
using Abacush.Application.Permissions.Queries;
using Abacush.Domain.Interfaces;

namespace Abacush.Application.Permissions.Handlers;

public sealed class GetPermissionsQueryHandler(IUnitOfWork unitOfWork)
{
    public async Task<IReadOnlyList<PermissionResponse>> Handle(
        GetPermissionsQuery request,
        CancellationToken cancellationToken)
    {
        var permissions = await unitOfWork.Permissions.ListDetailedAsync(cancellationToken);
        return permissions.Select(permission => permission.ToResponse()).ToList();
    }
}
