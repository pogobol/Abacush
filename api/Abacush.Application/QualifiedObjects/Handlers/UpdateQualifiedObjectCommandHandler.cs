using Abacush.Application.QualifiedObjects.Commands;
using Abacush.Application.QualifiedObjects.Dtos;
using Abacush.Domain.Interfaces;

namespace Abacush.Application.QualifiedObjects.Handlers;

public sealed class UpdateQualifiedObjectCommandHandler(IUnitOfWork unitOfWork)
{
    public async Task<QualifiedObjectResponse?> Handle(
        UpdateQualifiedObjectCommand request,
        CancellationToken cancellationToken)
    {
        var qualifiedObject = await unitOfWork.QualifiedObjects.GetByIdAsync(request.Id, cancellationToken);
        if (qualifiedObject is null)
        {
            return null;
        }

        qualifiedObject.Name = request.Request.Name;
        qualifiedObject.Description = request.Request.Description;
        qualifiedObject.TypeId = request.Request.TypeId;
        qualifiedObject.Attributes = request.Request.Attributes is null
            ? new Dictionary<string, string>()
            : new Dictionary<string, string>(request.Request.Attributes);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return qualifiedObject.ToResponse();
    }
}
