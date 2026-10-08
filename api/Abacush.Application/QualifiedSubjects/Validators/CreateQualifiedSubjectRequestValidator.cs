using Abacush.Application.QualifiedSubjects.Dtos;
using FluentValidation;

namespace Abacush.Application.QualifiedSubjects.Validators;

public sealed class CreateQualifiedSubjectRequestValidator : AbstractValidator<CreateQualifiedSubjectRequest>
{
    public CreateQualifiedSubjectRequestValidator()
    {
        RuleFor(request => request.Name)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(request => request.Description)
            .MaximumLength(1000);

        RuleFor(request => request.Interface)
            .NotEmpty();

        RuleForEach(request => request.Attributes)
            .ChildRules(attribute =>
            {
                attribute.RuleFor(pair => pair.Key).NotEmpty();
                attribute.RuleFor(pair => pair.Value).NotNull();
            });
    }
}
