using FluentValidation;

namespace Library.Application.Features.Loans.Commands.CreateLoanCommand
{
    public class CreateLoanValidator : AbstractValidator<CreateLoanCommand>
    {
        public CreateLoanValidator()
        {
            RuleFor(x => x.BookId).NotEmpty().NotNull();
            RuleFor(x => x.UserId).NotEmpty().NotNull();
            RuleFor(x => x.Date).NotEmpty().NotNull();
        }
    }
}
