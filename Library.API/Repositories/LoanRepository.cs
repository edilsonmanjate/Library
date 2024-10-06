using Library.API.Entities;
using Library.API.Persistence;

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

        public async Task<Loan?> GetByIdAsync(int id)
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
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();
        }

        public async Task ReturnAsync(Loan loan, DateTime returnDate)
        {
            loan.returnDate = returnDate;
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();
        }

       
    }
}
