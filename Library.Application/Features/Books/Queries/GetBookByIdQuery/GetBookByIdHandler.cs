using AutoMapper;

using Library.Application.Common.Bases;
using Library.Application.DTOs;
using Library.Application.Repositories;

using MediatR;

namespace Library.Application.Features.Books.Queries.GetBookByIdQuery
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, BaseResponse<BookDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookByIdHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<BookDto>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<BookDto>();

            try
            {
                var book = await _bookRepository.Get(request.BookId, cancellationToken);

                if (book is not null)
                {
                    response.Data = _mapper.Map<BookDto>(book);
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
