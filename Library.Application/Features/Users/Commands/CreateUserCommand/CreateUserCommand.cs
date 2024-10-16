using Library.Application.Common.Bases;
using Library.Core.Enums;

using MediatR;

namespace Library.Application.Features.Users.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<BaseResponse<bool>>
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string FullName { get;  set; }
        public string DisplayName { get;  set; }
        public DateTime BirthDate { get;  set; }
        public string? Header { get;  set; }
        public string? Description { get;  set; }
        public UserStatus Status { get;  set; }
    }
}
