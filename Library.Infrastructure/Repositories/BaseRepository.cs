using Library.Application.Repositories;
using Library.Core.Entities;
using Library.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly LibraryDbContext Context;

        public BaseRepository(LibraryDbContext context)
        {
            Context = context;
        }

        public async Task<bool> Create(T entity)
        {
            await Context.AddAsync(entity);
            return true;
        }

        public async Task<bool> Update(T entity)
        {
            Context.Update(entity);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(T entity)
        {
            entity.Update();
            Context.Update(entity);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<T?> Get(Guid id, CancellationToken cancellationToken)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return Context.Set<T>().ToListAsync(cancellationToken);
        }
    }
}
