using AutoMapper;

using Library.Application.Common.Bases;
using Library.Application.DTOs;
using Library.Application.Repositories;

using MediatR;

namespace Library.Application.Features.Loans.Queries.GetAllLoansQuery
{
    public class GetAllLoanHandler : IRequestHandler<GetAllLoanQuery, BaseResponse<IEnumerable<LoanDto>>>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;

        public GetAllLoanHandler(ILoanRepository loanRepository, IMapper mapper)
        {
            _loanRepository = loanRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<LoanDto>>> Handle(GetAllLoanQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<LoanDto>>();

            try
            {
                var loans = await _loanRepository.GetAll(cancellationToken);

                if (loans is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<LoanDto>>(loans);
                    response.Success = true;
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
