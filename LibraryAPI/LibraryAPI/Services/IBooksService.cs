using LibraryAPI.Models.DTO;
using LibraryAPI.Models.QueryParameters;

namespace LibraryAPI.Services
{
    public interface IBooksService
    {
        Task<List<BookDto>> GetAllAsync();
        Task<BookDto?> GetByIdAsync(Guid id);
        Task<BookDto> CreateAsync(CreateBookRequestDto createBookRequestDto);
        Task<BookDto?> UpdateAsync(Guid id, UpdateBookRequestDto updateBookRequestDto);
        Task<BookDto?> DeleteAsync(Guid id);

        Task<List<BookDto>> GetBooksPagedAsync(QueryParameters queryParams);
    }
}
