using Abacush.Application.QualifiedSubjects.Dtos;
using Abacush.Domain.Entities;

namespace Abacush.Application.QualifiedSubjects;

internal static class QualifiedSubjectMapping
{
    public static QualifiedSubjectResponse ToResponse(this QualifiedSubject subject)
    {
        return new QualifiedSubjectResponse(
            subject.Id,
            subject.Name,
            subject.Description,
            subject.Interface,
            new Dictionary<string, string>(subject.Attributes));
    }
}
