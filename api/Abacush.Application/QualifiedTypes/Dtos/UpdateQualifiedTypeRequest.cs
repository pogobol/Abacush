namespace Abacush.Application.QualifiedTypes.Dtos;

public sealed record UpdateQualifiedTypeRequest(
    string Name,
    string? Description,
    string Interface);
