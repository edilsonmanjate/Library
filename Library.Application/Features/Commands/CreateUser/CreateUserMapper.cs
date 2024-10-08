using AutoMapper;

using Library.Application.DTOs;
using Library.Core.Entities;

namespace Library.Application.Features.Commands.CreateUser
{
    public sealed class CreateUserMapper : Profile
    {
        public CreateUserMapper()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();

            CreateMap<User, userInputModel>();
            CreateMap<userInputModel, UserDto>();

        }
    }
}
