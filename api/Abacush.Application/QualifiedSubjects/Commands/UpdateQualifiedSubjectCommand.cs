using Abacush.Application.QualifiedSubjects.Dtos;

namespace Abacush.Application.QualifiedSubjects.Commands;

public sealed record UpdateQualifiedSubjectCommand(Guid Id, UpdateQualifiedSubjectRequest Request);
