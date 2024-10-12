using Library.Application.Repositories;
using Library.Core.Entities;
using Library.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class UserRepository :  BaseRepository<User>, IUserRepository
    {
        public UserRepository(LibraryDbContext _context) : base(_context)
        {
        }

        public async Task<User> GetByEmail(string email, CancellationToken cancellationToken)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }
    }
}
