using Abacush.Application.QualifiedObjects.Dtos;
using Abacush.Application.QualifiedObjects.Queries;
using Abacush.Domain.Interfaces;

namespace Abacush.Application.QualifiedObjects.Handlers;

public sealed class GetQualifiedObjectByIdQueryHandler(IUnitOfWork unitOfWork)
{
    public async Task<QualifiedObjectResponse?> Handle(
        GetQualifiedObjectByIdQuery request,
        CancellationToken cancellationToken)
    {
        var qualifiedObject = await unitOfWork.QualifiedObjects.GetByIdAsync(request.Id, cancellationToken);
        return qualifiedObject?.ToResponse();
    }
}
