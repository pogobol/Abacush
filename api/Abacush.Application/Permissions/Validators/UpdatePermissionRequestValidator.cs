using Abacush.Application.Permissions.Dtos;
using FluentValidation;

namespace Abacush.Application.Permissions.Validators;

public sealed class UpdatePermissionRequestValidator : AbstractValidator<UpdatePermissionRequest>
{
    public UpdatePermissionRequestValidator()
    {
        RuleFor(request => request.ObjectId)
            .NotEmpty();

        RuleFor(request => request.SubjectIds)
            .NotNull()
            .Must(subjectIds => subjectIds!.Count > 0)
            .WithMessage("At least one subject is required.");

        RuleForEach(request => request.SubjectIds)
            .NotEmpty();

        RuleFor(request => request.Actions)
            .NotNull()
            .Must(actions => actions!.Count > 0)
            .WithMessage("At least one action is required.");

        RuleForEach(request => request.Actions)
            .NotEmpty()
            .MaximumLength(200);
    }
}
