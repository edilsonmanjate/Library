using FluentValidation;

namespace Library.Application.Features.Users.Commands.CreateUserCommand
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email is not valid.");

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("FullName is required.");

            RuleFor(x => x.DisplayName)
                .NotEmpty().WithMessage("DisplayName is required.");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("BirthDate is required.");

            RuleFor(x => x.Header)
                .MaximumLength(100).WithMessage("Header must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Status is not valid.");

        }
    }
}
