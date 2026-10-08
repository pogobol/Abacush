namespace Abacush.Application.QualifiedObjects.Dtos;

public sealed record UpdateQualifiedObjectRequest(
    string Name,
    string? Description,
    Guid TypeId,
    Dictionary<string, string>? Attributes);
