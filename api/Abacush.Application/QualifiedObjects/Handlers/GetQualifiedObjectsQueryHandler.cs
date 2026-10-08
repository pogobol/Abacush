using Abacush.Application.QualifiedObjects.Dtos;
using Abacush.Application.QualifiedObjects.Queries;
using Abacush.Domain.Interfaces;

namespace Abacush.Application.QualifiedObjects.Handlers;

public sealed class GetQualifiedObjectsQueryHandler(IUnitOfWork unitOfWork)
{
    public async Task<IReadOnlyList<QualifiedObjectResponse>> Handle(
        GetQualifiedObjectsQuery request,
        CancellationToken cancellationToken)
    {
        var qualifiedObjects = await unitOfWork.QualifiedObjects.ListAsync(cancellationToken);
        return qualifiedObjects.Select(qualifiedObject => qualifiedObject.ToResponse()).ToList();
    }
}
