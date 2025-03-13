using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.BL.DTO
{
    public class UpdateBookRequestDto
    {
        [MaxLength(255)]
        public string? Name { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        //[Url]
        //public required string ContentUrl { get; set; }

        public Guid? AuthorId { get; set; }

        public IFormFile? ContentFile { get; set; }
    }
}
