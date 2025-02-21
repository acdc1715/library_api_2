namespace LibraryAPI.Models.Domain
{
    public class Author
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
