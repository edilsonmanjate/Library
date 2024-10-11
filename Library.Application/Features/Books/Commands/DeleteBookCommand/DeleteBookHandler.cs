using AutoMapper;

using Library.Application.Common.Bases;
using Library.Application.Repositories;
using Library.Core.Entities;

using MediatR;

namespace Library.Application.Features.Books.Commands.DeleteBookCommand
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, BaseResponse<bool>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBookHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponse<bool>> Handle(DeleteBookCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var book = _mapper.Map<Book>(command);
                response.Data = await _bookRepository.Delete(book);
                await _unitOfWork.Save(cancellationToken);

                if (response.Data)
                    response.succcess = true;
                    response.Message = "Delete succeed!";

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
