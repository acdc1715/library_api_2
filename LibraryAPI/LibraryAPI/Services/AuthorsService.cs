using AutoMapper;
using LibraryAPI.Models.Domain;
using LibraryAPI.Models.DTO;
using LibraryAPI.Models.QueryParameters;
using LibraryAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services
{
    public class AuthorsService : IAuthorsService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorsService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<List<AuthorDto>> GetAllAsync()
        {
            var query = _authorRepository.GetAll();

            var authors = await query.ToListAsync();

            return _mapper.Map<List<AuthorDto>>(authors);
        }

        public async Task<AuthorDto?> GetByIdAsync(Guid id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            return author != null ? _mapper.Map<AuthorDto>(author) : null;
        }

        public async Task<AuthorDto> CreateAsync(CreateAuthorRequestDto createAuthorRequestDto)
        {
            var authorDomainModel = _mapper.Map<Author>(createAuthorRequestDto);
            authorDomainModel = await _authorRepository.CreateAsync(authorDomainModel);
            return _mapper.Map<AuthorDto>(authorDomainModel);
        }

        public async Task<AuthorDto?> UpdateAsync(Guid id, UpdateAuthorRequestDto updateAuthorRequestDto)
        {
            var authorDomainModel = _mapper.Map<Author>(updateAuthorRequestDto);
            authorDomainModel = await _authorRepository.UpdateAsync(id, authorDomainModel);

            return authorDomainModel != null ? _mapper.Map<AuthorDto>(authorDomainModel) : null;
        }

        public async Task<AuthorDto?> DeleteAsync(Guid id)
        {
            var authorModel = await _authorRepository.DeleteAsync(id);
            return authorModel != null ? _mapper.Map<AuthorDto>(authorModel) : null;
        }
    }
}
