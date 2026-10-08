using Abacush.Application.QualifiedTypes.Commands;
using Abacush.Domain.Interfaces;

namespace Abacush.Application.QualifiedTypes.Handlers;

public sealed class DeleteQualifiedTypeCommandHandler(IUnitOfWork unitOfWork)
{
    public async Task<bool> Handle(
        DeleteQualifiedTypeCommand request,
        CancellationToken cancellationToken)
    {
        var qualifiedType = await unitOfWork.QualifiedTypes.GetByIdAsync(request.Id, cancellationToken);
        if (qualifiedType is null)
        {
            return false;
        }

        unitOfWork.QualifiedTypes.Remove(qualifiedType);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}
