using FluentValidation;

using Library.Application.DTOs;

namespace Library.Application.Features.Commands.CreateUser
{
    public sealed class CreateUserValidator : AbstractValidator<userInputModel>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
        }
    }
}
