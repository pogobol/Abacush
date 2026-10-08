namespace Abacush.Application.Permissions.Dtos;

public sealed record UpdatePermissionRequest(
    Guid ObjectId,
    IReadOnlyList<Guid>? SubjectIds,
    IReadOnlyList<string>? Actions);
