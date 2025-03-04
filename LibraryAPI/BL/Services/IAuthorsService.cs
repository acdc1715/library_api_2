using LibraryAPI.Models.DTO;
using LibraryAPI.Models.QueryParameters;

namespace LibraryAPI.Services
{
    public interface IAuthorsService
    {
        Task<List<AuthorDto>> GetAllAsync();
        Task<AuthorDto?> GetByIdAsync(Guid id);
        Task<AuthorDto> CreateAsync(CreateAuthorRequestDto addAuthorRequestDto);
        Task<AuthorDto?> UpdateAsync(Guid id, UpdateAuthorRequestDto updateAuthorRequestDto);
        Task<AuthorDto?> DeleteAsync(Guid id);
    }
}
