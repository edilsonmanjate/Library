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

        public async Task Create(T entity)
        {
            Context.Add(entity);
        }

        public async Task Update(T entity)
        {
             Context.Update(entity);
        }

        public async Task Delete(T entity)
        {
            entity.Update();
            Context.Update(entity);
        }

        public  Task<T> Get(Guid id, CancellationToken cancellationToken)
        {
            return Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return Context.Set<T>().ToListAsync(cancellationToken);
        }
    }
}
