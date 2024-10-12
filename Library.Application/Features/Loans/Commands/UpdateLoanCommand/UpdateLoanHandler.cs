using AutoMapper;

using Library.Application.Common.Bases;
using Library.Application.Repositories;
using Library.Core.Entities;

using MediatR;

namespace Library.Application.Features.Loans.Commands.UpdateLoanCommand
{
    public class UpdateLoanHandler : IRequestHandler<UpdateLoanCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;

        public UpdateLoanHandler(IUnitOfWork unitOfWork, ILoanRepository loanRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _loanRepository = loanRepository ?? throw new ArgumentNullException(nameof(loanRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponse<bool>> Handle(UpdateLoanCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var loan = _mapper.Map<Loan>(command);
                response.Data = await _loanRepository.Update(loan);
                await _unitOfWork.Save(cancellationToken);

                if (response.Data)
                    response.Success = true;
                    response.Message = "Loan update succeed!";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
