using AutoMapper;

using Library.Application.Common.Bases;
using Library.Application.Repositories;
using Library.Core.Entities;

using MediatR;

namespace Library.Application.Features.Books.Commands.UpdateBookCommand
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, BaseResponse<bool>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBookHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var book = _mapper.Map<Book>(request);
                response.Data = await _bookRepository.Update(book);
                await _unitOfWork.Save(cancellationToken);

                if (response.Data)
                {
                    response.succcess = true;
                    response.Message = "Update succeed!";
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
