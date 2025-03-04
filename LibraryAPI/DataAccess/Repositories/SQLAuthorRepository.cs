using LibraryAPI.DataAccess;
using LibraryAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Author>> GetAllAsync()
        {
            return await dbContext.Authors.ToListAsync();
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
