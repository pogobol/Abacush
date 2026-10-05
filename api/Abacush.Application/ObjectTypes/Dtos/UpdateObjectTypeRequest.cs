namespace Abacush.Application.ObjectTypes.Dtos;

public sealed record UpdateObjectTypeRequest(
    string Name,
    string? Description,
    string Interface);
