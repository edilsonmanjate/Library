using FluentValidation;

namespace Library.Application.Features.Loans.Commands.ReturnLoanCommand
{
    public class ReturnLoanValidator : AbstractValidator<ReturnLoanCommand>
    {
        public ReturnLoanValidator()
        {
            RuleFor(x => x.Loan.Id)
                .NotNull().WithMessage("Loan Id is required");

            RuleFor(x => x.ReturnDate)
                .NotNull().WithMessage("Return date is required")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Return date must be equals or less than today");
        }
    }
}
