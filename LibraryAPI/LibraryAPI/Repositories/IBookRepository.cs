using LibraryAPI.Models.Domain;

namespace LibraryAPI.Repositories
{
    public interface IBookRepository
    {
        Task<Book> CreateAsync(Book book);

        IQueryable<Book> GetAll();

        Task<Book?> GetByIdAsync(Guid id);

        Task<Book?> UpdateAsync(Guid id, Book book);

        Task<Book?> DeleteAsync(Guid id);
        Task<List<Book>> GetBooksPagedAsync(string? searchQuery, Guid? authorId, string? sortBy, /*bool isAscending, */int pageNumber, int pageSize);
    }
}
