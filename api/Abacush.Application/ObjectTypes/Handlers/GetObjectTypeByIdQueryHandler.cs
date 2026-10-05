using Abacush.Application.ObjectTypes.Dtos;
using Abacush.Application.ObjectTypes.Queries;
using Abacush.Domain.Interfaces;
using MediatR;

namespace Abacush.Application.ObjectTypes.Handlers;

public sealed class GetObjectTypeByIdQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetObjectTypeByIdQuery, ObjectTypeResponse?>
{
    public async Task<ObjectTypeResponse?> Handle(
        GetObjectTypeByIdQuery request,
        CancellationToken cancellationToken)
    {
        var objectType = await unitOfWork.ObjectTypes.GetByIdAsync(request.Id, cancellationToken);
        return objectType?.ToResponse();
    }
}
