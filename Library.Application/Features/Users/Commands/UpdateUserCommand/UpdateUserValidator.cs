using FluentValidation;

namespace Library.Application.Features.Users.Commands.UpdateUserCommand
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.FullName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.DisplayName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .EmailAddress().WithMessage("{PropertyName} must be a valid email address.");

            RuleFor(p => p.Header)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.BirthDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .LessThan(DateTime.Now).WithMessage("{PropertyName} must be a valid date of birth.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Status is not valid.");
        }
    }
}
