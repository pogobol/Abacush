using Abacush.Application.Permissions.Dtos;

namespace Abacush.Application.Permissions.Commands;

public sealed record UpdatePermissionCommand(Guid Id, UpdatePermissionRequest Request);
