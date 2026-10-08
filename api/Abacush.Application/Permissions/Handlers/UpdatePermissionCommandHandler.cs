using Abacush.Application.Permissions.Commands;
using Abacush.Application.Permissions.Dtos;
using Abacush.Domain.Interfaces;

namespace Abacush.Application.Permissions.Handlers;

public sealed class UpdatePermissionCommandHandler(
    IUnitOfWork unitOfWork)
{
    public async Task<PermissionResponse?> Handle(
        UpdatePermissionCommand request,
        CancellationToken cancellationToken)
    {
        var permission = await unitOfWork.Permissions.GetDetailedByIdAsync(request.Id, cancellationToken);
        var qualifiedObject = await unitOfWork.QualifiedObjects.GetByIdAsync(request.Request.ObjectId, cancellationToken);
        if (permission is null || qualifiedObject is null || request.Request.SubjectIds is null)
        {
            return null;
        }

        var subjects = new List<Domain.Entities.QualifiedSubject>();
        foreach (var subjectId in request.Request.SubjectIds)
        {
            var subject = await unitOfWork.QualifiedSubjects.GetByIdAsync(subjectId, cancellationToken);
            if (subject is null)
            {
                return null;
            }

            subjects.Add(subject);
        }

        permission.ObjectId = qualifiedObject.Id;
        permission.Object = qualifiedObject;
        permission.Subjects = subjects;
        permission.Actions = request.Request.Actions?.ToList() ?? [];

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return permission.ToResponse();
    }
}
