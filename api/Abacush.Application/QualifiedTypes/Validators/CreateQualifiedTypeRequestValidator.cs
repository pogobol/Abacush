using Abacush.Application.QualifiedTypes.Dtos;
using FluentValidation;

namespace Abacush.Application.QualifiedTypes.Validators;

public sealed class CreateQualifiedTypeRequestValidator : AbstractValidator<CreateQualifiedTypeRequest>
{
    public CreateQualifiedTypeRequestValidator()
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
