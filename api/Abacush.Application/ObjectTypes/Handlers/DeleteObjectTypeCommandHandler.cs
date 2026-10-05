using Abacush.Application.ObjectTypes.Commands;
using Abacush.Domain.Interfaces;
using MediatR;

namespace Abacush.Application.ObjectTypes.Handlers;

public sealed class DeleteObjectTypeCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteObjectTypeCommand, bool>
{
    public async Task<bool> Handle(
        DeleteObjectTypeCommand request,
        CancellationToken cancellationToken)
    {
        var objectType = await unitOfWork.ObjectTypes.GetByIdAsync(request.Id, cancellationToken);
        if (objectType is null)
        {
            return false;
        }

        unitOfWork.ObjectTypes.Remove(objectType);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}
