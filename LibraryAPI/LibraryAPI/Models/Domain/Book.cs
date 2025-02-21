namespace LibraryAPI.Models.Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

        public required string ContentUrl { get; set; }

        public Guid AuthorId { get; set; }


        //Navigation properties
        public required Author Author { get; set; }
    }
}
