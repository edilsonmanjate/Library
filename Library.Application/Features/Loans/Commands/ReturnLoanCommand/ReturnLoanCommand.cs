using Library.Application.Common.Bases;
using Library.Core.Entities;

using MediatR;

namespace Library.Application.Features.Loans.Commands.ReturnLoanCommand
{
    public class ReturnLoanCommand : IRequest<BaseResponse<bool>>
    {
        public Loan Loan { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}
