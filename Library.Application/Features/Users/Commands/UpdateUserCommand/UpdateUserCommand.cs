using Library.Application.DTOs;

using MediatR;

namespace Library.Application.Features.Users.Commands.UpdateUserCommand
{
    public class UpdateUserCommand : IRequest<UserDto>
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
    }
}
