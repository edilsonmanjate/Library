using AutoMapper;

using Library.Application.DTOs;
using Library.Application.Features.Books.Commands.CreateBookCommand;
using Library.Application.Features.Books.Commands.UpdateBookCommand;
using Library.Core.Entities;

namespace Library.Application.Common.Mappings
{
    public class BookMapper : Profile
    {
        public BookMapper()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, CreateBookCommand>().ReverseMap();
            CreateMap<Book, UpdateBookCommand>().ReverseMap();

        }
    }
}
