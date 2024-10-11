using AutoMapper;

using Library.Application.DTOs;
using Library.Core.Entities;

namespace Library.Application.Common.Mappings
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDto>().ReverseMap();
            //CreateMap<User, CreateLoanCommand>().ReverseMap();
            //CreateMap<User, UpdateLoanCommand>().ReverseMap();
        }
    }
}
