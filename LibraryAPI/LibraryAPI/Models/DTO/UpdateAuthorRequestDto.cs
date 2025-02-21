using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.DTO
{
    public class UpdateAuthorRequestDto
    {
        [MaxLength(50, ErrorMessage = "Name has to be maximum of 50 characters")]
        public string? Name { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
