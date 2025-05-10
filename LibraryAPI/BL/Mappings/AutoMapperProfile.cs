using AutoMapper;
using LibraryAPI.Domain.Entities;
using LibraryAPI.BL.DTO;

namespace LibraryAPI.BL.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Author, CreateAuthorRequestDto>().ReverseMap();
            CreateMap<Author, UpdateAuthorRequestDto>().ReverseMap();
            CreateMap<Book, CreateBookRequestDto>().ReverseMap();
            CreateMap<Book, UpdateBookRequestDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}
