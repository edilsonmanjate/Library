﻿using Library.API.Entities;
using Library.API.Persistence;

namespace Library.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private LibraryDbContext _context;

        public UserRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
