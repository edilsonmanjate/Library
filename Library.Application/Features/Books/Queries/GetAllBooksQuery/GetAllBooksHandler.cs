using AutoMapper;

using Library.Application.Common.Bases;
using Library.Application.DTOs;
using Library.Application.Repositories;

using MediatR;

namespace Library.Application.Features.Books.Queries.GetAllBooksQuery
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, BaseResponse<IEnumerable<BookDto>>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetAllBooksHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<BookDto>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<BookDto>>();

            try
            {
                var books = await _bookRepository.GetAll(cancellationToken);

                if (books is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<BookDto>>(books);
                    response.succcess = true;
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
