using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.DTO
{
    public class CreateBookRequestDto
    {
        [Required]
        [MaxLength(255)]
        public required string Name { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        //[Required]
        //[Url]
        //public required string ContentUrl { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public required IFormFile ContentFile { get; set; }
    }
}
