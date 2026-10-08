using Abacush.Application.Permissions.Dtos;
using Abacush.Domain.Entities;

namespace Abacush.Application.Permissions;

internal static class PermissionMapping
{
    public static PermissionResponse ToResponse(this Permission permission)
    {
        return new PermissionResponse(
            permission.Id,
            permission.ObjectId,
            permission.Subjects.Select(subject => subject.Id).ToList(),
            permission.Actions.ToList());
    }
}
