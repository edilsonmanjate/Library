using Library.Application.Repositories;
using Library.Core.Entities;
using Library.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Library.Infrastructure.Repositories
{
    public class LoanRepository : BaseRepository<Loan>, ILoanRepository
    {
        private readonly LibraryDbContext _context;
        public LoanRepository(LibraryDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Loan>> GetByUser(Guid userId, CancellationToken cancellationToken)
        {
            return await _context.Loans
                .Where(loan => loan.UserId == userId)
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> ReturnAsync(Loan loan, DateTime returnDate, CancellationToken cancellationToken)
        {
            loan.UpdateReturnDate(returnDate);
            _context.Loans.Update(loan);
            return true;
        }

    
    }
}
