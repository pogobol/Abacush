namespace Abacush.Application.QualifiedSubjects.Dtos;

public sealed record CreateQualifiedSubjectRequest(
    string Name,
    string? Description,
    string Interface,
    Dictionary<string, string>? Attributes);
