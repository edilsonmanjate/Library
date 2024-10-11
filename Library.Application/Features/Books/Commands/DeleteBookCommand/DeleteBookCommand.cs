using Library.Application.Common.Bases;

using MediatR;

namespace Library.Application.Features.Books.Commands.DeleteBookCommand
{
    public class DeleteBookCommand : IRequest<BaseResponse<bool>>
    {
        public Guid Id { get; set; }
    }
}
