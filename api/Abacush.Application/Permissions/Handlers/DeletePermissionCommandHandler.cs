using Abacush.Application.Permissions.Commands;
using Abacush.Domain.Interfaces;

namespace Abacush.Application.Permissions.Handlers;

public sealed class DeletePermissionCommandHandler(IUnitOfWork unitOfWork)
{
    public async Task<bool> Handle(
        DeletePermissionCommand request,
        CancellationToken cancellationToken)
    {
        var permission = await unitOfWork.Permissions.GetByIdAsync(request.Id, cancellationToken);
        if (permission is null)
        {
            return false;
        }

        unitOfWork.Permissions.Remove(permission);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
