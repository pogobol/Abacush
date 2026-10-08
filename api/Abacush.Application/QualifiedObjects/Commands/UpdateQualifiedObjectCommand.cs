using Abacush.Application.QualifiedObjects.Dtos;

namespace Abacush.Application.QualifiedObjects.Commands;

public sealed record UpdateQualifiedObjectCommand(Guid Id, UpdateQualifiedObjectRequest Request);
