using LibraryAPI.CustomActionFilters;
using LibraryAPI.Models.DTO;
using LibraryAPI.Models.QueryParameters;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsService _authorsService;

        public AuthorsController(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authorsDto = await _authorsService.GetAllAsync();
            return Ok(authorsDto);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var authorDto = await _authorsService.GetByIdAsync(id);
            if (authorDto == null)
            {
                return NotFound();
            }

            return Ok(authorDto);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] CreateAuthorRequestDto createAuthorRequestDto)
        {
            var authorDto = await _authorsService.CreateAsync(createAuthorRequestDto);
            return CreatedAtAction(nameof(GetById), new { id = authorDto.Id }, authorDto);
        }

        [HttpPut("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateAuthorRequestDto updateAuthorRequestDto)
        {
            var authorDto = await _authorsService.UpdateAsync(id, updateAuthorRequestDto);
            if (authorDto == null)
            {
                return NotFound();
            }

            return Ok(authorDto);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var authorDto = await _authorsService.DeleteAsync(id);
            if (authorDto == null)
            {
                return NotFound();
            }

            return Ok(authorDto);
        }
    }
}
