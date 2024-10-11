using Library.Application.Common.Bases;
using Library.Application.DTOs;

using MediatR;

namespace Library.Application.Features.Loans.Queries.GetAllLoansQuery
{
    public class GetAllLoanQuery : IRequest<BaseResponse<IEnumerable<LoanDto>>>
    {
    }
}
