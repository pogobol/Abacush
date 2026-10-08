namespace Abacush.Application.QualifiedObjects.Dtos;

public sealed record QualifiedObjectResponse(
    Guid Id,
    string Name,
    string? Description,
    Guid TypeId,
    IReadOnlyDictionary<string, string> Attributes);
