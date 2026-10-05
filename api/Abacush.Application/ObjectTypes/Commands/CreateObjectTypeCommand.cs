using Abacush.Application.ObjectTypes.Dtos;
using MediatR;

namespace Abacush.Application.ObjectTypes.Commands;

public sealed record CreateObjectTypeCommand(CreateObjectTypeRequest Request) : IRequest<ObjectTypeResponse>;
