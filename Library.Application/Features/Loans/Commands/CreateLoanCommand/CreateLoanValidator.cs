using FluentValidation;

namespace Library.Application.Features.Loans.Commands.CreateLoanCommand
{
    public class CreateLoanValidator : AbstractValidator<CreateLoanCommand>
    {
        public CreateLoanValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.BookId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.");


            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.");


            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Data must be less or equal to Today {DateTime.Now}");
        }
    }
}
