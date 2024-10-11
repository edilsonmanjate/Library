using Library.Application.Repositories;
using Library.Core.Entities;
using Library.Infrastructure.Persistence;

namespace Library.Infrastructure.Repositories
{
    public class LoanRepository : BaseRepository<Loan>, ILoanRepository
    {
        private readonly LibraryDbContext _context;
        public LoanRepository(LibraryDbContext context) : base(context)
        {
            _context = context;
        }   
      
        public async Task ReturnAsync(Loan loan, DateTime returnDate)
        {
            loan.UpdateReturnDate(returnDate);

            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();
        }

    }
}
