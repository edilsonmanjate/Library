using Library.Application.DTOs;

using MediatR;

namespace Library.Application.Features.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<BaseResult<List<GetUsersViewModel>>>
    {
        public GetUsersQuery() { }

    }
}
