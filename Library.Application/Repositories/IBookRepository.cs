using Library.Core.Entities;

namespace Library.Application.Repositories
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        //Task<Book> GetByIdAsync(Guid id);

    }
}
