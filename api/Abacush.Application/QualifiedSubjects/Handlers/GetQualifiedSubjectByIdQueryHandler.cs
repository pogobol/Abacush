using Abacush.Application.QualifiedSubjects.Dtos;
using Abacush.Application.QualifiedSubjects.Queries;
using Abacush.Domain.Interfaces;

namespace Abacush.Application.QualifiedSubjects.Handlers;

public sealed class GetQualifiedSubjectByIdQueryHandler(IUnitOfWork unitOfWork)
{
    public async Task<QualifiedSubjectResponse?> Handle(
        GetQualifiedSubjectByIdQuery request,
        CancellationToken cancellationToken)
    {
        var subject = await unitOfWork.QualifiedSubjects.GetByIdAsync(request.Id, cancellationToken);
        return subject?.ToResponse();
    }
}
