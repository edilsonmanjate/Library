using Library.API.Entities;

namespace Library.API.Repositories
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);
    }
}
