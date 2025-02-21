using AutoMapper;
using LibraryAPI.Data;
using LibraryAPI.Models.Domain;
using LibraryAPI.Models.DTO;
using LibraryAPI.Models.QueryParameters;
using LibraryAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBlobStorageService _blobStorageService;
        private readonly IMapper _mapper;

        public BooksService(IBookRepository bookRepository, IBlobStorageService blobStorageService, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _blobStorageService = blobStorageService;
            _mapper = mapper;
        }

        public async Task<List<BookDto>> GetAllAsync()
        {
            var query = _bookRepository.GetAll();

            var booksModel = await query.ToListAsync();
            return _mapper.Map<List<BookDto>>(booksModel);
        }

        public async Task<BookDto?> GetByIdAsync(Guid id)
        {
            var bookModel = await _bookRepository.GetByIdAsync(id);
            return bookModel != null ? _mapper.Map<BookDto>(bookModel) : null;
        }

        public async Task<BookDto> CreateAsync(CreateBookRequestDto createBookRequestDto)
        {
            string fileUrl = await _blobStorageService.UploadBlobAsync(createBookRequestDto.ContentFile);

            var bookModel = _mapper.Map<Book>(createBookRequestDto);
            bookModel.ContentUrl = fileUrl;

            bookModel = await _bookRepository.CreateAsync(bookModel);

            return _mapper.Map<BookDto>(bookModel);
        }

        public async Task<BookDto?> UpdateAsync(Guid id, UpdateBookRequestDto updateBookRequestDto)
        {
            var existingBook = await _bookRepository.GetByIdAsync(id);
            if (existingBook == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(updateBookRequestDto.Name))
                existingBook.Name = updateBookRequestDto.Name;

            if (!string.IsNullOrEmpty(updateBookRequestDto.Description))
                existingBook.Description = updateBookRequestDto.Description;

            if (updateBookRequestDto.AuthorId != null)
                existingBook.AuthorId = updateBookRequestDto.AuthorId ?? Guid.Empty;

            if (updateBookRequestDto.ContentFile != null)
            {
                await _blobStorageService.DeleteBlobAsync(existingBook.ContentUrl);

                string newContentUrl = await _blobStorageService.UploadBlobAsync(updateBookRequestDto.ContentFile);
                existingBook.ContentUrl = newContentUrl;
            }
           
           

            var bookModel = await _bookRepository.UpdateAsync(id, existingBook);

            return bookModel != null ? _mapper.Map<BookDto>(bookModel) : null;
        }

        public async Task<BookDto?> DeleteAsync(Guid id)
        {
            var existingBook = await _bookRepository.GetByIdAsync(id);
            if (existingBook == null)
            {
                return null;
            }

            await _blobStorageService.DeleteBlobAsync(existingBook.ContentUrl);

            var bookModel = await _bookRepository.DeleteAsync(id);
            return bookModel != null ? _mapper.Map<BookDto>(bookModel) : null;
        }

        public async Task<List<BookDto>> GetBooksPagedAsync(QueryParameters queryParams)
        {
            var books = await _bookRepository.GetBooksPagedAsync(
                queryParams.SearchQuery,
                queryParams.AuthorID,
                queryParams.SortBy,
                //queryParams.IsAscending,
                queryParams.PageNumber,
                queryParams.PageSize);
            return _mapper.Map<List<BookDto>>(books);
        }
    }
}
