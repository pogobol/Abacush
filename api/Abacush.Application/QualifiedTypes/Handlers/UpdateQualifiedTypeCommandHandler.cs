using Abacush.Application.QualifiedTypes.Commands;
using Abacush.Application.QualifiedTypes.Dtos;
using Abacush.Domain.Interfaces;

namespace Abacush.Application.QualifiedTypes.Handlers;

public sealed class UpdateQualifiedTypeCommandHandler(IUnitOfWork unitOfWork)
{
    public async Task<QualifiedTypeResponse?> Handle(
        UpdateQualifiedTypeCommand request,
        CancellationToken cancellationToken)
    {
        var qualifiedType = await unitOfWork.QualifiedTypes.GetByIdAsync(request.Id, cancellationToken);
        if (qualifiedType is null)
        {
            return null;
        }

        qualifiedType.Name = request.Request.Name;
        qualifiedType.Description = request.Request.Description;
        qualifiedType.Interface = request.Request.Interface;

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return qualifiedType.ToResponse();
    }
}
