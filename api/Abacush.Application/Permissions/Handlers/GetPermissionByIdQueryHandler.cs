using Abacush.Application.Permissions.Dtos;
using Abacush.Application.Permissions.Queries;
using Abacush.Domain.Interfaces;

namespace Abacush.Application.Permissions.Handlers;

public sealed class GetPermissionByIdQueryHandler(IUnitOfWork unitOfWork)
{
    public async Task<PermissionResponse?> Handle(
        GetPermissionByIdQuery request,
        CancellationToken cancellationToken)
    {
        var permission = await unitOfWork.Permissions.GetDetailedByIdAsync(request.Id, cancellationToken);
        return permission?.ToResponse();
    }
}
