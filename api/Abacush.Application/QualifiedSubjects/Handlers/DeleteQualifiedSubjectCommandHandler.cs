using Abacush.Application.QualifiedSubjects.Commands;
using Abacush.Domain.Interfaces;

namespace Abacush.Application.QualifiedSubjects.Handlers;

public sealed class DeleteQualifiedSubjectCommandHandler(IUnitOfWork unitOfWork)
{
    public async Task<bool> Handle(
        DeleteQualifiedSubjectCommand request,
        CancellationToken cancellationToken)
    {
        var subject = await unitOfWork.QualifiedSubjects.GetByIdAsync(request.Id, cancellationToken);
        if (subject is null)
        {
            return false;
        }

        unitOfWork.QualifiedSubjects.Remove(subject);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}
