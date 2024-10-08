using Library.Application.DTOs;
using Library.Application.Repositories;

using MediatR;

using System.Collections.Generic;

namespace Library.Application.Features.Queries.GetUsers
{
    public class GetUsersQueryHandler  // : IRequestHandler<GetUsersQuery,<BaseResult<GetUsersViewModel>>>
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public GetUsersQueryHandler(IUserRepository repository, IUnitOfWork unitOfWork = null)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        //public async Task<List<BaseResult<GetUsersViewModel>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        //{
        //    var users = await _repository.GetAll(cancellationToken);
        //    var result = users.Select(user => new BaseResult<GetUsersViewModel>
        //    {
        //        Data = new GetUsersViewModel
        //        {
        //            Email = user.Email,
        //            Name = user.DisplayName
        //        }
        //    }).ToList();

        //    return result;
        //}
    }
}
