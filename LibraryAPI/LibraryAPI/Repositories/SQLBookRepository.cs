using LibraryAPI.Data;
using LibraryAPI.Models.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repositories
{
    public class SQLBookRepository : IBookRepository
    {
        private readonly LibraryDbContext dbContext;

        public SQLBookRepository(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Book> CreateAsync(Book book)
        {
            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();

            return book;
        }

        public async Task<Book?> DeleteAsync(Guid id)
        {
            var book = await dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);

            if(book == null)
            {
                return null;
            }

            dbContext.Books.Remove(book);
            await dbContext.SaveChangesAsync();

            return book;
        }

        public IQueryable<Book> GetAll()
        {
            return dbContext.Books.AsQueryable();
        }

        public async Task<Book?> GetByIdAsync(Guid id)
        {
            return await dbContext.Books
                .Include("Author")
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Book?> UpdateAsync(Guid id, Book book)
        {
           var existingBook = await dbContext.Books.FirstOrDefaultAsync(x =>x.Id == id);

            if(existingBook == null)
            {
                return null;
            }

            existingBook.Name = book.Name;
            existingBook.Description = book.Description;
            existingBook.ContentUrl = book.ContentUrl;
            existingBook.AuthorId = book.AuthorId;

            await dbContext.SaveChangesAsync();

            return existingBook;
            
        }

        public async Task<List<Book>> GetBooksPagedAsync(string? searchQuery, Guid? authorId,
            string? sortBy, /*bool isAscending, */int pageNumber, int pageSize)
        {
            var books = await dbContext.Books
                .FromSqlRaw("EXEC GetBooksPaged @SearchQuery, @FilterByAuthorId, @SortBy, @PageNumber, @PageSize",
                    new SqlParameter("@SearchQuery", searchQuery ?? (object)DBNull.Value),
                    new SqlParameter("@FilterByAuthorId", authorId ?? (object)DBNull.Value),
                    new SqlParameter("@SortBy", sortBy ?? (object)DBNull.Value),
                    //new SqlParameter("@IsAscending", isAscending),
                    new SqlParameter("@PageNumber", pageNumber),
                    new SqlParameter("@PageSize", pageSize))
                .ToListAsync();

            return books;
        }
    }
}
