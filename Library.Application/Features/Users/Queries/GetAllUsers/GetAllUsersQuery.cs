using Library.Application.Common.Bases;
using Library.Application.DTOs;

using MediatR;

namespace Library.Application.Features.Users.Queries.GetUsers
{
    public class GetAllUsersQuery : IRequest<BaseResponse<IEnumerable<UserDto>>>
    {

    }
}
