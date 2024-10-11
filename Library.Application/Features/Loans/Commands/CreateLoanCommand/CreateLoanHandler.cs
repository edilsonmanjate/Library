using AutoMapper;

using Library.Application.Common.Bases;
using Library.Application.Repositories;
using Library.Core.Entities;

using MediatR;

namespace Library.Application.Features.Loans.Commands.CreateLoanCommand
{
    public class CreateLoanHandler : IRequestHandler<CreateLoanCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;

        public CreateLoanHandler(IUnitOfWork unitOfWork, IMapper mapper, ILoanRepository loanRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _loanRepository = loanRepository;
        }

        public async Task<BaseResponse<bool>> Handle(CreateLoanCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var loan = _mapper.Map<Loan>(command);
                response.Data = await _loanRepository.Create(loan);
                await _unitOfWork.Save(cancellationToken);
                
                if (response.Data)
                    response.succcess = true;
                    response.Message = "Loan create succeed!";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
