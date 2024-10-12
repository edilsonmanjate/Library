using AutoMapper;

using Library.Application.Common.Bases;
using Library.Application.DTOs;
using Library.Application.Repositories;

using MediatR;

namespace Library.Application.Features.Loans.Queries.GetLoanByUserQuery
{
    public class GetLoanByUserHandler : IRequestHandler<GetLoanByUserQuery, BaseResponse<IEnumerable<LoanDto>>>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;

        public GetLoanByUserHandler(ILoanRepository loanRepository, IMapper mapper)
        {
            _loanRepository = loanRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<LoanDto>>> Handle(GetLoanByUserQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<LoanDto>>();

            try
            {
                var loans = await _loanRepository.GetByUser(request.UserId, cancellationToken);

                if (loans is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<LoanDto>>(loans);
                    response.succcess = true;
                    response.Message = "Query succeed!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
