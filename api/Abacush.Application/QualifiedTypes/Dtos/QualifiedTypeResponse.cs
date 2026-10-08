namespace Abacush.Application.QualifiedTypes.Dtos;

public sealed record QualifiedTypeResponse(
    Guid Id,
    string Name,
    string? Description,
    string Interface);
