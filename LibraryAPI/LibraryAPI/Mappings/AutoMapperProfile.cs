using AutoMapper;
using LibraryAPI.Models.Domain;
using LibraryAPI.Models.DTO;

namespace LibraryAPI.Mappings
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
