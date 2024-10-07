using Library.Core.Entities;

namespace Library.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);
    }
}
