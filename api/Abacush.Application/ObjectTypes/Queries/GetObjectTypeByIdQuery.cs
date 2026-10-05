using Abacush.Application.ObjectTypes.Dtos;
using MediatR;

namespace Abacush.Application.ObjectTypes.Queries;

public sealed record GetObjectTypeByIdQuery(Guid Id) : IRequest<ObjectTypeResponse?>;
