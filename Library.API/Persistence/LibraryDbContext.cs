
using Library.Core.Entities;

using Microsoft.EntityFrameworkCore;

namespace Library.API.Persistence
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users{ get; set; }
    }
 
}
