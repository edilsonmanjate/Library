using Library.Application.Common.Bases;
using Library.Application.DTOs;

using MediatR;

namespace Library.Application.Features.Books.Queries.GetAllBooksQuery
{
    public class GetAllBooksQuery : IRequest<BaseResponse<IEnumerable<BookDto>>>
    {
    }
}
