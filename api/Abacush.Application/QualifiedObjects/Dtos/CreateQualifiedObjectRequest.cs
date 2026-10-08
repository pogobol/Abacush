namespace Abacush.Application.QualifiedObjects.Dtos;

public sealed record CreateQualifiedObjectRequest(
    string Name,
    string? Description,
    Guid TypeId,
    Dictionary<string, string>? Attributes);
