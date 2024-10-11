using AutoMapper;
using Library.Application.DTOs;
using Library.Application.Repositories;
using Library.Core.Entities;

using MediatR;

namespace Library.Application.Features.Users.Commands.CreateUser
{
    public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Name, request.Name, DateTime.Now, request.Email);

            await _userRepository.Create(user);
            await _unitOfWork.Save(cancellationToken);

            return _mapper.Map<UserDto>(user);
        }
    }
}
