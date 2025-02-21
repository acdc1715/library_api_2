using LibraryAPI.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Repositories
{
    public interface IAuthorRepository
    {
        IQueryable<Author> GetAll();

        Task<Author?> GetByIdAsync(Guid id);

        Task<Author> CreateAsync(Author author);

        Task<Author?> UpdateAsync(Guid id, Author author);

        Task<Author?> DeleteAsync(Guid id);
    }
}
