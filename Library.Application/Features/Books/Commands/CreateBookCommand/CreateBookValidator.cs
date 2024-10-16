using FluentValidation;

namespace Library.Application.Features.Books.Commands.CreateBookCommand
{
    public class CreateBookValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Length(2,50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Author)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.ISBN)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.PublicationYear)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .LessThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must be a Year in the past.");

          }
    }
}
