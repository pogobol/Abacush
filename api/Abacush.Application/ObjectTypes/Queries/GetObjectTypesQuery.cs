using Abacush.Application.ObjectTypes.Dtos;
using MediatR;

namespace Abacush.Application.ObjectTypes.Queries;

public sealed record GetObjectTypesQuery : IRequest<IReadOnlyList<ObjectTypeResponse>>;
