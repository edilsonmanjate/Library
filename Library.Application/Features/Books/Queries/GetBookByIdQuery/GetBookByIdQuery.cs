using Library.Application.Common.Bases;
using Library.Application.DTOs;

using MediatR;

namespace Library.Application.Features.Books.Queries.GetBookByIdQuery
{
    public class GetBookByIdQuery : IRequest<BaseResponse<BookDto>>
    {
        public Guid BookId { get; set; }
    }
}
