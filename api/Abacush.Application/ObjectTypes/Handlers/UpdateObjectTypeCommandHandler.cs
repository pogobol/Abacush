using Abacush.Application.ObjectTypes.Commands;
using Abacush.Application.ObjectTypes.Dtos;
using Abacush.Domain.Interfaces;
using MediatR;

namespace Abacush.Application.ObjectTypes.Handlers;

public sealed class UpdateObjectTypeCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateObjectTypeCommand, ObjectTypeResponse?>
{
    public async Task<ObjectTypeResponse?> Handle(
        UpdateObjectTypeCommand request,
        CancellationToken cancellationToken)
    {
        var objectType = await unitOfWork.ObjectTypes.GetByIdAsync(request.Id, cancellationToken);
        if (objectType is null)
        {
            return null;
        }

        objectType.Name = request.Request.Name;
        objectType.Description = request.Request.Description;
        objectType.Interface = request.Request.Interface;

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return objectType.ToResponse();
    }
}
