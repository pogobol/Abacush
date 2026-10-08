using Abacush.Application.QualifiedTypes.Dtos;
using Abacush.Application.QualifiedTypes.Queries;
using Abacush.Domain.Interfaces;

namespace Abacush.Application.QualifiedTypes.Handlers;

public sealed class GetQualifiedTypesQueryHandler(IUnitOfWork unitOfWork)
{
    public async Task<IReadOnlyList<QualifiedTypeResponse>> Handle(
        GetQualifiedTypesQuery request,
        CancellationToken cancellationToken)
    {
        var qualifiedTypes = await unitOfWork.QualifiedTypes.ListAsync(cancellationToken);
        return qualifiedTypes.Select(qualifiedType => qualifiedType.ToResponse()).ToList();
    }
}
