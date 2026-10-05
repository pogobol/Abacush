namespace Abacush.Application.ObjectTypes.Dtos;

public sealed record CreateObjectTypeRequest(
    string Name,
    string? Description,
    string Interface);
