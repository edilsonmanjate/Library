namespace Library.Application.DTOs
{
    public class LoanDto
    {
        public Guid Id { get; set; }
        public Guid BookId { get;  set; }
        public Guid UserId { get;  set; }
        public DateTime Date { get;  set; }
        public DateTime ReturnDate { get; set; }

    }
}
