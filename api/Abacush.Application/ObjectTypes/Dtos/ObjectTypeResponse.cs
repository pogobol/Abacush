namespace Abacush.Application.ObjectTypes.Dtos;

public sealed record ObjectTypeResponse(
    Guid Id,
    string Name,
    string? Description,
    string Interface);
