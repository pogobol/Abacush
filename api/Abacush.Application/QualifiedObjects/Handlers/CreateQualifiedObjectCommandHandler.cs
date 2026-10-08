using Abacush.Application.QualifiedObjects.Commands;
using Abacush.Application.QualifiedObjects.Dtos;
using Abacush.Domain.Entities;
using Abacush.Domain.Interfaces;

namespace Abacush.Application.QualifiedObjects.Handlers;

public sealed class CreateQualifiedObjectCommandHandler(IUnitOfWork unitOfWork)
{
    public async Task<QualifiedObjectResponse> Handle(
        CreateQualifiedObjectCommand request,
        CancellationToken cancellationToken)
    {
        var qualifiedObject = new QualifiedObject
        {
            Name = request.Request.Name,
            Description = request.Request.Description,
            TypeId = request.Request.TypeId,
            Type = null!,
            Attributes = request.Request.Attributes is null
                ? new Dictionary<string, string>()
                : new Dictionary<string, string>(request.Request.Attributes)
        };

        unitOfWork.QualifiedObjects.Add(qualifiedObject);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return qualifiedObject.ToResponse();
    }
}
