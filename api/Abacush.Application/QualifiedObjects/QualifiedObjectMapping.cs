using Abacush.Application.QualifiedObjects.Dtos;
using Abacush.Domain.Entities;

namespace Abacush.Application.QualifiedObjects;

internal static class QualifiedObjectMapping
{
    public static QualifiedObjectResponse ToResponse(this QualifiedObject qualifiedObject)
    {
        return new QualifiedObjectResponse(
            qualifiedObject.Id,
            qualifiedObject.Name,
            qualifiedObject.Description,
            qualifiedObject.TypeId,
            new Dictionary<string, string>(qualifiedObject.Attributes));
    }
}
