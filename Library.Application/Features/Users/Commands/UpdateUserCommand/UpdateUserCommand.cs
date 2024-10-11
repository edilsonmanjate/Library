using Library.Application.DTOs;
using Library.Core.Enums;

using MediatR;

namespace Library.Application.Features.Users.Commands.UpdateUserCommand
{
    public class UpdateUserCommand : IRequest<UserDto>
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Header { get; set; }
        public string? Description { get; set; }
        public UserStatus Status { get; set; }
    }
}
