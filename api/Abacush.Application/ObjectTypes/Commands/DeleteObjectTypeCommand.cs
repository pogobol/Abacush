using MediatR;

namespace Abacush.Application.ObjectTypes.Commands;

public sealed record DeleteObjectTypeCommand(Guid Id) : IRequest<bool>;
