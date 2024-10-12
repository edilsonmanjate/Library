using AutoMapper;

using Library.Application.Common.Bases;
using Library.Application.Repositories;
using Library.Core.Entities;

using MediatR;

namespace Library.Application.Features.Users.Commands.UpdateUserCommand
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, BaseResponse<bool>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public async Task<BaseResponse<bool>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var user = _mapper.Map<User>(command);
                response.Data = await _userRepository.Update(user);
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
