using Abacush.Application.QualifiedSubjects.Commands;
using Abacush.Application.QualifiedSubjects.Dtos;
using Abacush.Domain.Interfaces;

namespace Abacush.Application.QualifiedSubjects.Handlers;

public sealed class UpdateQualifiedSubjectCommandHandler(IUnitOfWork unitOfWork)
{
    public async Task<QualifiedSubjectResponse?> Handle(
        UpdateQualifiedSubjectCommand request,
        CancellationToken cancellationToken)
    {
        var subject = await unitOfWork.QualifiedSubjects.GetByIdAsync(request.Id, cancellationToken);
        if (subject is null)
        {
            return null;
        }

        subject.Name = request.Request.Name;
        subject.Description = request.Request.Description;
        subject.Interface = request.Request.Interface;
        subject.Attributes = request.Request.Attributes is null
            ? new Dictionary<string, string>()
            : new Dictionary<string, string>(request.Request.Attributes);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return subject.ToResponse();
    }
}
