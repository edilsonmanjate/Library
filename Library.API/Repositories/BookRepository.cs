﻿using Library.API.Persistence;
using Library.Core.Entities;

using Microsoft.EntityFrameworkCore;

namespace Library.API.Repositories
{

    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;
        private readonly IConfiguration _configuration;

        public BookRepository(LibraryDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task CreateAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            if (await GetByIdAsync(id) == null)
            {
                throw new InvalidOperationException("Book not found");
            }

            _context.Remove(await GetByIdAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
          return _context.Books.AsNoTracking();
        }

        public async Task<Book?> GetByIdAsync(Guid id)
        {
            return await _context.Books.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task UpdateAsync(Book book)
        {
            if (await GetByIdAsync(book.Id) == null)
            {
                throw new InvalidOperationException("Book not found");
            }
            _context.Update(book);
            await _context.SaveChangesAsync();
        }

    }
}
