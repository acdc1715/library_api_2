namespace LibraryAPI.Models.Domain
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
