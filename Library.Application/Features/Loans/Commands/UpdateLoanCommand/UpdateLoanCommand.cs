using Library.Application.Common.Bases;

using MediatR;

namespace Library.Application.Features.Loans.Commands.UpdateLoanCommand
{
    public class UpdateLoanCommand : IRequest<BaseResponse<bool>>
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
