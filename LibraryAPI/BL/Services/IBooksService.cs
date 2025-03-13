using LibraryAPI.BL.DTO;
using LibraryAPI.BL.QueryParams;

namespace LibraryAPI.BL.Services
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
