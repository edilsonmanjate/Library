using Library.Application.Common.Bases;

using MediatR;

namespace Library.Application.Features.Books.Commands.UpdateBookCommand
{
    public class UpdateBookCommand : IRequest<BaseResponse<bool>>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
    }
}
