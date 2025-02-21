using LibraryAPI.CustomActionFilters;
using LibraryAPI.Models.DTO;
using LibraryAPI.Models.QueryParameters;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var booksDto = await _booksService.GetAllAsync();

        //    return Ok(booksDto);
        //}

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryParameters queryParams)
        {
            var booksDto = await _booksService.GetBooksPagedAsync(queryParams);

            return Ok(booksDto);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var bookDto = await _booksService.GetByIdAsync(id);
            if (bookDto == null)
            {
                return NotFound();
            }

            return Ok(bookDto);
        }
        [HttpPost]
        [ValidateModel] 
        public async Task<IActionResult> Create([FromForm] CreateBookRequestDto createBookRequestDto)
        {
            var bookDto = await _booksService.CreateAsync(createBookRequestDto);
            return CreatedAtAction(nameof(GetById), new { id = bookDto.Id }, bookDto);
        }

        [HttpPut("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromForm] UpdateBookRequestDto updateBookRequestDto)
        {
            var bookDto = await _booksService.UpdateAsync(id, updateBookRequestDto);
            if (bookDto == null)
            {
                return NotFound();
            }

            return Ok(bookDto);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var bookDto = await _booksService.DeleteAsync(id);
            if (bookDto == null)
            {
                return NotFound();
            }

            return Ok(bookDto);
        }
    }
}
