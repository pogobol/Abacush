using Abacush.Application.ObjectTypes.Dtos;
using Abacush.Domain.Entities;

namespace Abacush.Application.ObjectTypes;

internal static class ObjectTypeMapping
{
    public static ObjectTypeResponse ToResponse(this ObjectType objectType)
    {
        return new ObjectTypeResponse(
            objectType.Id,
            objectType.Name,
            objectType.Description,
            objectType.Interface);
    }
}
