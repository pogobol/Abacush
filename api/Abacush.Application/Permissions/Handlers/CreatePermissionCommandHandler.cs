using Abacush.Application.Permissions.Commands;
using Abacush.Application.Permissions.Dtos;
using Abacush.Domain.Entities;
using Abacush.Domain.Interfaces;

namespace Abacush.Application.Permissions.Handlers;

public sealed class CreatePermissionCommandHandler(IUnitOfWork unitOfWork)
{
    public async Task<PermissionResponse> Handle(
        CreatePermissionCommand request,
        CancellationToken cancellationToken)
    {
        var qualifiedObject = await unitOfWork.QualifiedObjects.GetByIdAsync(
            request.Request.ObjectId,
            cancellationToken);
        if (qualifiedObject is null || request.Request.SubjectIds is null)
        {
            throw new InvalidOperationException("The permission references an entity that does not exist.");
        }

        var subjects = new List<QualifiedSubject>();
        foreach (var subjectId in request.Request.SubjectIds)
        {
            var subject = await unitOfWork.QualifiedSubjects.GetByIdAsync(subjectId, cancellationToken);
            if (subject is null)
            {
                throw new InvalidOperationException("The permission references an entity that does not exist.");
            }

            subjects.Add(subject);
        }

        var permission = new Permission
        {
            ObjectId = qualifiedObject.Id,
            Object = qualifiedObject,
            Subjects = subjects,
            Actions = request.Request.Actions?.ToList() ?? []
        };

        unitOfWork.Permissions.Add(permission);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return permission.ToResponse();
    }
}
