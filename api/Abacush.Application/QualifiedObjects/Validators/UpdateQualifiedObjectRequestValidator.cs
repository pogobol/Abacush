using Abacush.Application.QualifiedObjects.Dtos;
using FluentValidation;

namespace Abacush.Application.QualifiedObjects.Validators;

public sealed class UpdateQualifiedObjectRequestValidator : AbstractValidator<UpdateQualifiedObjectRequest>
{
    public UpdateQualifiedObjectRequestValidator()
    {
        RuleFor(request => request.Name)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(request => request.Description)
            .MaximumLength(1000);

        RuleFor(request => request.TypeId)
            .NotEmpty();

        RuleForEach(request => request.Attributes)
            .ChildRules(attribute =>
            {
                attribute.RuleFor(pair => pair.Key).NotEmpty();
                attribute.RuleFor(pair => pair.Value).NotNull();
            });
    }
}
