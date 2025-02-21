using LibraryAPI.Data;
using LibraryAPI.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace LibraryAPI.Repositories
{
    public class SQLAuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext dbContext;

        public SQLAuthorRepository(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Author> CreateAsync(Author author)
        {
            await dbContext.Authors.AddAsync(author);
            await dbContext.SaveChangesAsync();

            return author;
        }

        public async Task<Author?> DeleteAsync(Guid id)
        {
            var existingAuthor = await dbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);

            if(existingAuthor == null)
            {
                return null;
            }

            dbContext.Authors.Remove(existingAuthor);
            await dbContext.SaveChangesAsync();

            return existingAuthor;
        }

        public IQueryable<Author> GetAll()
        {
            return dbContext.Authors.AsQueryable();
        }

        public async Task<Author?> GetByIdAsync(Guid id)
        {
            return await dbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Author?> UpdateAsync(Guid id, Author author)
        {
            var existingAuthor = await dbContext.Authors.FirstOrDefaultAsync( x => x.Id == id);

            if(existingAuthor == null)
            {
                return null;
            }

            existingAuthor.Name = author.Name;
            existingAuthor.Birthday = author.Birthday;

            await dbContext.SaveChangesAsync();

            return existingAuthor;
        }
    }
}
