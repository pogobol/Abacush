using Abacush.Application.QualifiedTypes.Commands;
using Abacush.Application.QualifiedTypes.Dtos;
using Abacush.Domain.Entities;
using Abacush.Domain.Interfaces;

namespace Abacush.Application.QualifiedTypes.Handlers;

public sealed class CreateQualifiedTypeCommandHandler(IUnitOfWork unitOfWork)
{
    public async Task<QualifiedTypeResponse> Handle(
        CreateQualifiedTypeCommand request,
        CancellationToken cancellationToken)
    {
        var qualifiedType = new QualifiedType
        {
            Name = request.Request.Name,
            Description = request.Request.Description,
            Interface = request.Request.Interface
        };

        unitOfWork.QualifiedTypes.Add(qualifiedType);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return qualifiedType.ToResponse();
    }
}
