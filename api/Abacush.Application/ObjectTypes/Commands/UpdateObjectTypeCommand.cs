using Abacush.Application.ObjectTypes.Dtos;
using MediatR;

namespace Abacush.Application.ObjectTypes.Commands;

public sealed record UpdateObjectTypeCommand(Guid Id, UpdateObjectTypeRequest Request) : IRequest<ObjectTypeResponse?>;
