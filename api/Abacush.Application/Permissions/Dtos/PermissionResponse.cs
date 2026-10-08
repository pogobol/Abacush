namespace Abacush.Application.Permissions.Dtos;

public sealed record PermissionResponse(
    Guid Id,
    Guid ObjectId,
    IReadOnlyList<Guid> SubjectIds,
    IReadOnlyList<string> Actions);
