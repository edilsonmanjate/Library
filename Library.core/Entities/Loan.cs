namespace Library.Core.Entities
{
    public class Loan : BaseEntity
    {
        public Loan(Guid bookId, Guid userId, DateTime date, DateTime returnDate)
        {
            BookId = bookId;
            UserId = userId;
            Date = date;
            ReturnDate = returnDate;
        }

        public Guid BookId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime Date { get; private set; }
        public DateTime ReturnDate { get; private set; }
        public  Book Book { get; set; }
        public User User { get; set; }

        public void UpdateReturnDate(DateTime returnDate)
        {
            ReturnDate = returnDate;
        }
    }
}
    