namespace Library.Application.DTOs
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get;  set; }
        public string? ISBN { get; set; }
        public int PublicationYear { get; private set; }

    }
}
