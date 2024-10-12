using AutoMapper;

using Library.Application.Common.Bases;
using Library.Application.Repositories;
using Library.Core.Entities;

using MediatR;

namespace Library.Application.Features.Books.Commands.CreateBookCommand
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, BaseResponse<bool>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBookHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var book = _mapper.Map<Book>(command); 
                response.Data = await _bookRepository.Create(book);
                await _unitOfWork.Save(cancellationToken);
                
                if (response.Data)
                    response.Data = true;
                    response.Message = "Book created successfully";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;  
            }

            return response;    
        }
    }
}
