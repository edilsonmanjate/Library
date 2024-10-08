﻿using Library.Application.Repositories;
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

        public Task<User> GetByEmail(string email, CancellationToken cancellationToken)
        {
            return Context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }
    }
}
