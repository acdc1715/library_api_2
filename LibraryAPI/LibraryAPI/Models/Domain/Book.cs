namespace LibraryAPI.Models.Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public string ContentUrl { get; set; }

        public Guid AuthorId { get; set; }


        //Navigation properties
        public Author Author { get; set; }
    }
}
