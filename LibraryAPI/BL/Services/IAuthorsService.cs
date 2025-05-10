using LibraryAPI.BL.DTO;

namespace LibraryAPI.BL.Services
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
