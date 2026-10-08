using Abacush.Application.QualifiedObjects.Commands;
using Abacush.Domain.Interfaces;

namespace Abacush.Application.QualifiedObjects.Handlers;

public sealed class DeleteQualifiedObjectCommandHandler(IUnitOfWork unitOfWork)
{
    public async Task<bool> Handle(
        DeleteQualifiedObjectCommand request,
        CancellationToken cancellationToken)
    {
        var qualifiedObject = await unitOfWork.QualifiedObjects.GetByIdAsync(request.Id, cancellationToken);
        if (qualifiedObject is null)
        {
            return false;
        }

        unitOfWork.QualifiedObjects.Remove(qualifiedObject);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}
