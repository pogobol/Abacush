using Abacush.Application.QualifiedTypes.Dtos;
using Abacush.Application.QualifiedTypes.Queries;
using Abacush.Domain.Interfaces;

namespace Abacush.Application.QualifiedTypes.Handlers;

public sealed class GetQualifiedTypeByIdQueryHandler(IUnitOfWork unitOfWork)
{
    public async Task<QualifiedTypeResponse?> Handle(
        GetQualifiedTypeByIdQuery request,
        CancellationToken cancellationToken)
    {
        var qualifiedType = await unitOfWork.QualifiedTypes.GetByIdAsync(request.Id, cancellationToken);
        return qualifiedType?.ToResponse();
    }
}
