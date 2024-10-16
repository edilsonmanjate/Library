using FluentValidation;

namespace Library.Application.Features.Books.Commands.DeleteBookCommand
{
    public class DeleteBookValidator: AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
