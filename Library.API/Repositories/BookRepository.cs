using Library.API.Entities;
using Library.API.Persistence;

using Microsoft.EntityFrameworkCore;

namespace Library.API.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Book book)
        {
            await _context.Books.AddAsync(book);
        }

        public async Task DeleteAsync(int id)
        {
            _context.Remove(await GetByIdAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
          return _context.Books.AsNoTracking();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Update(book);

        }
   
    }
}
