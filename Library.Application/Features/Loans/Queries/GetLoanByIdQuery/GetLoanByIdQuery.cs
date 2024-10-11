using Library.Application.Common.Bases;
using Library.Application.DTOs;

using MediatR;

namespace Library.Application.Features.Loans.Queries.GetLoanByIdQuery
{
    public class GetLoanByIdQuery : IRequest<BaseResponse<LoanDto>>
    {
        public Guid LoanId { get; set; }
    }
}
