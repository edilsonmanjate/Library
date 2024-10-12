using Library.Application.Common.Bases;
using Library.Application.DTOs;

using MediatR;

namespace Library.Application.Features.Loans.Queries.GetLoanByUserQuery
{
    public class GetLoanByUserQuery : IRequest<BaseResponse<IEnumerable<LoanDto>>>
    {
        public Guid UserId { get; set; }
    }
}
