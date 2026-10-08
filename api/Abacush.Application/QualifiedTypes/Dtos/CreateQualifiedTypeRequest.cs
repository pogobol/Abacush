namespace Abacush.Application.QualifiedTypes.Dtos;

public sealed record CreateQualifiedTypeRequest(
    string Name,
    string? Description,
    string Interface);
