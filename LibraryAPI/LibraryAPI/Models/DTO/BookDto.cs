namespace LibraryAPI.Models.DTO
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public string ContentUrl { get; set; } = string.Empty;

        public Guid AuthorId { get; set; }
        public required AuthorDto Author { get; set; }
    }
}
