using FluentValidation;
using Library.Application.DTOs;

namespace Library.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserValidator : AbstractValidator<UserDto>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
        }
    }
}
