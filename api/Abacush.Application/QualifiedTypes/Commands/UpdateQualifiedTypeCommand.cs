using Abacush.Application.QualifiedTypes.Dtos;

namespace Abacush.Application.QualifiedTypes.Commands;

public sealed record UpdateQualifiedTypeCommand(Guid Id, UpdateQualifiedTypeRequest Request);
