namespace Abacush.Application.QualifiedSubjects.Dtos;

public sealed record QualifiedSubjectResponse(
    Guid Id,
    string Name,
    string? Description,
    string Interface,
    IReadOnlyDictionary<string, string> Attributes);
