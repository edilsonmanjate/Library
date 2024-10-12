namespace Library.Application.DTOs
{
    public class BookDto
    {
        public Guid BookId { get; set; }
        public string? Title { get; set; }
        public string? Author { get;  set; }
        public string? ISBN { get; set; }
    }
}
