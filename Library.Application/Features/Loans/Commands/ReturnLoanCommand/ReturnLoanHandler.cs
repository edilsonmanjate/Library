using AutoMapper;

using Library.Application.Common.Bases;
using Library.Application.Repositories;
using Library.Core.Entities;

using MediatR;

namespace Library.Application.Features.Loans.Commands.ReturnLoanCommand
{
    public class ReturnLoanHandler : IRequestHandler<ReturnLoanCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;

        public ReturnLoanHandler(IUnitOfWork unitOfWork, ILoanRepository loanRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _loanRepository = loanRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(ReturnLoanCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var loan = _mapper.Map<Loan>(command.Loan);
                response.Data = await _loanRepository.ReturnAsync(loan, command.ReturnDate, cancellationToken);
                await _unitOfWork.Save(cancellationToken);

                if (response.Data)
                    response.Success = true;
                    response.Message = "Book returned with succeed!";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
