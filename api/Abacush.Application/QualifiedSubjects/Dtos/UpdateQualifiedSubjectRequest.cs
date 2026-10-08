namespace Abacush.Application.QualifiedSubjects.Dtos;

public sealed record UpdateQualifiedSubjectRequest(
    string Name,
    string? Description,
    string Interface,
    Dictionary<string, string>? Attributes);
