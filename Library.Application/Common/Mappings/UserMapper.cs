using AutoMapper;

using Library.Application.DTOs;
using Library.Application.Features.Users.Commands.CreateUserCommand;
using Library.Application.Features.Users.Commands.UpdateUserCommand;
using Library.Core.Entities;

namespace Library.Application.Common.Mappings
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
        }
    }
}
