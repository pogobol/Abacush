using Abacush.Application.ObjectTypes.Dtos;
using Abacush.Application.ObjectTypes.Queries;
using Abacush.Domain.Interfaces;
using MediatR;

namespace Abacush.Application.ObjectTypes.Handlers;

public sealed class GetObjectTypesQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetObjectTypesQuery, IReadOnlyList<ObjectTypeResponse>>
{
    public async Task<IReadOnlyList<ObjectTypeResponse>> Handle(
        GetObjectTypesQuery request,
        CancellationToken cancellationToken)
    {
        var objectTypes = await unitOfWork.ObjectTypes.ListAsync(cancellationToken);
        return objectTypes.Select(objectType => objectType.ToResponse()).ToList();
    }
}
