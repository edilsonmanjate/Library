using AutoMapper;

using Library.Application.Common.Bases;
using Library.Application.DTOs;
using Library.Application.Repositories;

using MediatR;

namespace Library.Application.Features.Users.Queries.GetAllUsersQuery
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, BaseResponse<IEnumerable<UserDto>>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUsersHandler(IUserRepository repository, IMapper mapper)
        {
            _userRepository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<UserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<UserDto>>();

            try
            {
                var users = await _userRepository.GetAll(cancellationToken);

                if (users is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<UserDto>>(users);
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
