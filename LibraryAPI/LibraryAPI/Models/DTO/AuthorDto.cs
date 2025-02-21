namespace LibraryAPI.Models.DTO
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? Birthday { get; set; }
    }
}
