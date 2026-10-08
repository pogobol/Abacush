namespace Abacush.Application.Permissions.Dtos;

public sealed record CreatePermissionRequest(
    Guid ObjectId,
    IReadOnlyList<Guid>? SubjectIds,
    IReadOnlyList<string>? Actions);
