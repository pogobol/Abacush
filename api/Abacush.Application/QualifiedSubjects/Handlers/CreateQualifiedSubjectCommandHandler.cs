using Abacush.Application.QualifiedSubjects.Commands;
using Abacush.Application.QualifiedSubjects.Dtos;
using Abacush.Domain.Entities;
using Abacush.Domain.Interfaces;

namespace Abacush.Application.QualifiedSubjects.Handlers;

public sealed class CreateQualifiedSubjectCommandHandler(IUnitOfWork unitOfWork)
{
    public async Task<QualifiedSubjectResponse> Handle(
        CreateQualifiedSubjectCommand request,
        CancellationToken cancellationToken)
    {
        var subject = new QualifiedSubject
        {
            Name = request.Request.Name,
            Description = request.Request.Description,
            Interface = request.Request.Interface,
            Attributes = request.Request.Attributes is null
                ? new Dictionary<string, string>()
                : new Dictionary<string, string>(request.Request.Attributes)
        };

        unitOfWork.QualifiedSubjects.Add(subject);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return subject.ToResponse();
    }
}
