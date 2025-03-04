using LibraryAPI.Models.Domain;

namespace LibraryAPI.Repositories
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAsync();

        Task<Author?> GetByIdAsync(Guid id);

        Task<Author> CreateAsync(Author author);

        Task<Author?> UpdateAsync(Guid id, Author author);

        Task<Author?> DeleteAsync(Guid id);
    }
}
