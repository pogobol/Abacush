using Abacush.Application.QualifiedTypes.Dtos;
using Abacush.Domain.Entities;

namespace Abacush.Application.QualifiedTypes;

internal static class QualifiedTypeMapping
{
    public static QualifiedTypeResponse ToResponse(this QualifiedType qualifiedType)
    {
        return new QualifiedTypeResponse(
            qualifiedType.Id,
            qualifiedType.Name,
            qualifiedType.Description,
            qualifiedType.Interface);
    }
}
