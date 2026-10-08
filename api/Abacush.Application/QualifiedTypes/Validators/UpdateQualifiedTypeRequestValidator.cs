using Abacush.Application.QualifiedTypes.Dtos;
using FluentValidation;

namespace Abacush.Application.QualifiedTypes.Validators;

public sealed class UpdateQualifiedTypeRequestValidator : AbstractValidator<UpdateQualifiedTypeRequest>
{
    public UpdateQualifiedTypeRequestValidator()
    {
        RuleFor(request => request.Name)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(request => request.Description)
            .MaximumLength(1000);

        RuleFor(request => request.Interface)
            .NotEmpty();
    }
}
