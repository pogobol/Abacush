using Abacush.Application.QualifiedSubjects.Dtos;
using Abacush.Application.QualifiedSubjects.Queries;
using Abacush.Domain.Interfaces;

namespace Abacush.Application.QualifiedSubjects.Handlers;

public sealed class GetQualifiedSubjectsQueryHandler(IUnitOfWork unitOfWork)
{
    public async Task<IReadOnlyList<QualifiedSubjectResponse>> Handle(
        GetQualifiedSubjectsQuery request,
        CancellationToken cancellationToken)
    {
        var subjects = await unitOfWork.QualifiedSubjects.ListAsync(cancellationToken);
        return subjects.Select(subject => subject.ToResponse()).ToList();
    }
}
