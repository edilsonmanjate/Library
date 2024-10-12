using AutoMapper;

using Library.Application.Common.Bases;
using Library.Application.DTOs;
using Library.Application.Repositories;

using MediatR;

namespace Library.Application.Features.Loans.Queries.GetLoanByIdQuery
{
    public class GetLoanByIdHandler : IRequestHandler<GetLoanByIdQuery, BaseResponse<LoanDto>>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;

        public GetLoanByIdHandler(ILoanRepository loanRepository, IMapper mapper)
        {
            _loanRepository = loanRepository ?? throw new ArgumentNullException(nameof(loanRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponse<LoanDto>> Handle(GetLoanByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<LoanDto>();

            try
            {
                var loan = await _loanRepository.Get(request.LoanId, cancellationToken);

                if (loan is not null)
                {
                    response.Data = _mapper.Map<LoanDto>(loan);
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
