using Abacush.Application.ObjectTypes.Commands;
using Abacush.Application.ObjectTypes.Dtos;
using Abacush.Domain.Entities;
using Abacush.Domain.Interfaces;
using MediatR;

namespace Abacush.Application.ObjectTypes.Handlers;

public sealed class CreateObjectTypeCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateObjectTypeCommand, ObjectTypeResponse>
{
    public async Task<ObjectTypeResponse> Handle(
        CreateObjectTypeCommand request,
        CancellationToken cancellationToken)
    {
        var objectType = new ObjectType
        {
            Name = request.Request.Name,
            Description = request.Request.Description,
            Interface = request.Request.Interface
        };

        unitOfWork.ObjectTypes.Add(objectType);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return objectType.ToResponse();
    }
}
