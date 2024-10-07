using Library.API.Persistence;
using Library.Core.Entities;

using Microsoft.EntityFrameworkCore;

namespace Library.API.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private LibraryDbContext _context;

        public LoanRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<Loan?> GetByIdAsync(Guid id)
        {
            return await _context.Loans.FindAsync(id);
        }

        public async Task<IEnumerable<Loan>> GetAllAsync()
        {
            return await _context.Loans.ToListAsync();
        }
        public async Task CreateAsync(Loan loan)
        {
            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Loan loan)
        {
            if (await GetByIdAsync(loan.Id) == null)
                throw new InvalidOperationException("Loan not found");

            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();
        }

        public async Task ReturnAsync(Loan loan, DateTime returnDate)
        {
            if (await GetByIdAsync(loan.Id) == null)
                throw new InvalidOperationException("Loan not found");

            loan.UpdateReturnDate(returnDate);

            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();
        }

       
    }
}
